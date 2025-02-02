﻿/*
 * Copyright 2021 Sage Intacct, Inc.
 * 
 * Licensed under the Apache License, Version 2.0 (the "License"). You may not
 * use this file except in compliance with the License. You may obtain a copy 
 * of the License at
 * 
 * http://www.apache.org/licenses/LICENSE-2.0
 * 
 * or in the "LICENSE" file accompanying this file. This file is distributed on 
 * an "AS IS" BASIS, WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either 
 * express or implied. See the License for the specific language governing 
 * permissions and limitations under the License.
 */

using System;
using Intacct.SDK.Functions.InventoryControl;
using Intacct.SDK.Xml;

namespace Intacct.SDK.Functions.InventoryControl
{
    public class WarehouseTransferCreate : AbstractWarehouseTransfer
    {
        public WarehouseTransferCreate(string controlId = null) : base(controlId)
        {
        }

        public override void WriteXml(ref IaXmlWriter xml)
        {
            xml.WriteStartElement("function");
            xml.WriteAttribute("controlid", ControlId, true);

            xml.WriteStartElement("create");
            xml.WriteStartElement("ICTRANSFER");
            
            xml.WriteElement("TRANSACTIONDATE",TransactionDate, IaXmlWriter.IntacctDateFormat);
            xml.WriteElement("REFERENCENO", ReferenceNumber);
            xml.WriteElement("DESCRIPTION",Description);
            xml.WriteElement("TRANSFERTYPE", TransferType);
            xml.WriteElement("ACTION", Action);
            xml.WriteElement("OUTDATE", OutDate, IaXmlWriter.IntacctDateFormat);
            xml.WriteElement("INDATE", InDate, IaXmlWriter.IntacctDateFormat);
            xml.WriteElement("EXCH_RATE_TYPE_ID", ExchangeRateTypeId);
            
            if (ExchangeRateDate.HasValue)
            {
                xml.WriteElement("EXCH_RATE_DATE", ExchangeRateDate, IaXmlWriter.IntacctDateFormat);
            }
            
            xml.WriteElement("EXCHANGE_RATE", ExchangeRate);
            
            if (Lines.Count > 0)
            {
                xml.WriteStartElement("ICTRANSFERITEMS");
                foreach (WarehouseTransferLineCreate line in Lines)
                {
                    line.WriteXml(ref xml);
                }
                xml.WriteEndElement(); //ICTRANSFERITEMS
            }
            xml.WriteEndElement(); //ICTRANSFER
            xml.WriteEndElement(); //create
            xml.WriteEndElement(); //function
        }
    }
}