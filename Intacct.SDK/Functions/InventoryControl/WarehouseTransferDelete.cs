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

using System.Net.Mail;
using Intacct.SDK.Xml;

namespace Intacct.SDK.Functions.InventoryControl
{
    public class WarehouseTransferDelete : AbstractWarehouseTransfer
    {
        public WarehouseTransferDelete(string controlId = null) : base(controlId)
        {
        }

        public override void WriteXml(ref IaXmlWriter xml)
        {
            xml.WriteStartElement("function");
            xml.WriteAttribute("controlid", ControlId, true);
           
            xml.WriteStartElement("delete");

            xml.WriteElement("object", "ICTRANSFER");
            xml.WriteElement("keys", RecordNumber, true);
            
            xml.WriteEndElement(); //delete

            xml.WriteEndElement(); //function
        }
    }
}