EPI Processor
=============
This is a fairly simple implementation of a processor for the EPI 3.2 data format (CSV). This app will read EPI3.2 data and 
write it to a database.

The EPI 3.2 Specification is a data specification that enables client information to be exchanged between financial 
service providers and various financial planning platforms.

This code currently supports the following record types:
* HDR (header)
* AD (adviser details)
* CL (client details)
* ID (investment details)
* CM (cash movement transactions)
* CH (cash holding balances)
* SM (stock movement transactions)
* SH (stock holding balances)
* IN (income entitlements)
* TRL (trailer)
 
Technology used:
----------------
* FileHelpers 2.0
* Entity Framework 4.1 (Code First)
* AutoMapper 1.1
* NLog 2.0

Usage:
------
EPIProcessor.exe c:\Path\To\ORG_CCYYMMDD_AdviserID_ZZZ.CSV

* Files must match the file naming conventions ORG_CCYYMMDD_AdviserID_ZZZ.CSV
* Files must be processed in sequence
* 'Since Inception' file must be the first file loaded

Configuration
------------- 
The database can be configured by adding/modifing the connection string with name "EPIRepository" into the <connectionStrings> section 
of the application config file. For example:

    <connectionStrings>
       <add name="EPIRepository" connectionString="Server=.\SQLEXPRESS;Database=EPIRepo;Integrated Security=true" providerName="System.Data.SqlClient"/>    
    </connectionStrings>
	
