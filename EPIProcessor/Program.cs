using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.IO;
using System.Linq;
using AutoMapper;
using FileHelpers;
using EPIProcessor.Domain;
using EPIProcessor.Records;
using NLog;
using NLog.Config;

namespace EPIProcessor
{
    class Program
    {
        private static readonly Logger log = LogManager.GetCurrentClassLogger();
        private readonly IDictionary<string, Type> recordTypes;
        private readonly MultiRecordEngine engine;

        private Program(IDictionary<string, Type> recordTypes)
        {
            this.recordTypes = recordTypes;
            engine = new MultiRecordEngine(recordTypes.Values.ToArray());
            engine.RecordSelector = new RecordTypeSelector(CustomSelector);
        }

        private EpiFile Process(string fileName)
        {
            object[] res = engine.ReadFile(fileName);
            return new EpiFile(Path.GetFileName(fileName), res);            
        }

        private Type CustomSelector(MultiRecordEngine e, string recordstring)
        {
            string recordType = recordstring.Substring(0, recordstring.IndexOf(','));
            if (recordType.StartsWith("\""))
                recordType = recordType.Substring(1, recordType.Length - 2);

            Type t;
            if (recordTypes.TryGetValue(recordType, out t))
                return t;

            log.Warn("unable to decode record type {0}", recordType);
            return null;
        }

        static void Main(string[] args)
        {
            SimpleConfigurator.ConfigureForConsoleLogging();
            Database.SetInitializer(new DropCreateDatabaseIfModelChanges<EpiRepository>());
            SetupAutoMaps();
            Dictionary<string, Type> recordTypes = new Dictionary<string, Type>
                                                   {
                                                       {"HDR", typeof (Header)},
                                                       {"AD", typeof (AdviserDetails)},
                                                       {"CL", typeof (ClientDetails)},
                                                       {"ID", typeof (InvestmentDetails)},
                                                       {"CM", typeof (CashMovementTransaction)},
                                                       {"CH", typeof (CashHoldingBalance)},
                                                       {"SM", typeof (StockMovementTransaction)},
                                                       {"SH", typeof(StockHoldingBalance)},
                                                       {"IN", typeof (IncomeEntitlement)},
                                                       {"TRL", typeof (Footer)},
                                                   };

            try
            {
                var result = new Program(recordTypes).Process(args[0]);
                log.Debug("total records: {0}", result.Footer.RecordCount);
                new EpiFileProcessor(() => new EpiRepository()).ProcessFile(result);
            }
            catch (Exception ex)
            {
                log.Error("Error processing EPI Datafeed from file: {0}, {1}", args[0], ex);
                Environment.Exit(1);
            }
        }

        private static void SetupAutoMaps()
        {
            Mapper.CreateMap<StockMovementTransaction, Transaction>()
                .ForMember(x => x.ReversalOfTransaction, a => a.Ignore())
                .ForMember(x => x.Account, a => a.Ignore())
                .ForMember(x => x.Adviser, a => a.Ignore());
//                .ForMember(x => x.Investment, a => a.Ignore());
            Mapper.CreateMap<CashMovementTransaction, Transaction>()
                .ForMember(x => x.ReversalOfTransaction, a => a.Ignore())
                .ForMember(x => x.HoldingId, a => a.Ignore())
                .ForMember(x => x.TradeDate, a => a.MapFrom(y => y.TransactionDate))
                .ForMember(x => x.SettlementDate, a => a.MapFrom(y => y.TransactionDate))
                .ForMember(x => x.Quantity, a => a.MapFrom(y => y.Amount))
                .ForMember(x => x.NetValue, a => a.MapFrom(y => y.Amount))
                .ForMember(x => x.GrossValue, a => a.MapFrom(y => y.Amount))
                .ForMember(x => x.CostBase, a => a.MapFrom(y => y.Amount))
                .ForMember(x => x.StampDuty, a => a.Ignore())
                .ForMember(x => x.OutstandingOrderAmount, a => a.Ignore())
                .ForMember(x => x.ClientFees, a => a.Ignore())
                .ForMember(x => x.FeeRebates, a => a.Ignore())
                .ForMember(x => x.OtherFees, a => a.Ignore())
                .ForMember(x => x.PlatformOrderId, a => a.Ignore())
                .ForMember(x => x.Account, a => a.Ignore())
                .ForMember(x => x.Adviser, a => a.Ignore());
//                .ForMember(x => x.Investment, a => a.Ignore());
            Mapper.CreateMap<StockHoldingBalance, InvestmentBalance>()
                .ForMember(x => x.Account, a => a.Ignore())
                .ForMember(x => x.Adviser, a => a.Ignore());
            Mapper.CreateMap<CashHoldingBalance, InvestmentBalance>()
                .ForMember(x => x.Account, a => a.Ignore())
                .ForMember(x => x.Adviser, a => a.Ignore())
                .ForMember(x => x.HoldingId, a => a.Ignore());
            Mapper.CreateMap<AdviserDetails, Adviser>();
            Mapper.CreateMap<ClientDetails, Account>()
                .ForMember(x => x.Adviser, a => a.Ignore());
            Mapper.CreateMap<InvestmentDetails, Investment>();
            Mapper.CreateMap<IncomeEntitlement, Entitlement>()
                .ForMember(x => x.EntitlementId, a => a.MapFrom(y => y.TransactionId))
                .ForMember(x => x.ReversalOfEntitlementId, a => a.MapFrom(y => y.ReversalOfTransactionId))
//                .ForMember(x => x.Investment, a => a.Ignore())
                .ForMember(x => x.ReversalOfEntitlement, a => a.Ignore())
                .ForMember(x => x.LinkedToTransaction, a => a.Ignore())
                .ForMember(x => x.Account, a => a.Ignore())
                .ForMember(x => x.Adviser, a => a.Ignore());

            Mapper.AssertConfigurationIsValid();
        }
    }
}
