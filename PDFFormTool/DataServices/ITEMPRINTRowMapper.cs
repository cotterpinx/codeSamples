using Oracle.DataAccess.Client;
using Foo.Forms.Model;
using System;

namespace Foo.Forms.DataServices
{
    public class ITEMPRINTRowMapper
    {
        public void MapRow(OracleDataReader itemPrintApiReader, ITEMS itemForm)
        {
            if (itemPrintApiReader.HasRows)
            {
                while (itemPrintApiReader.Read())
                {
                    var itemData = new ITEMPRINT();

                    int column = itemPrintApiReader.GetOrdinal("formnum");
                    if (!itemPrintApiReader.IsDBNull(column))
                    {
                        itemData.FORMNUM = itemPrintApiReader.GetString(column);
                    }

                    column = itemPrintApiReader.GetOrdinal("hdrdockey");
                    if (!itemPrintApiReader.IsDBNull(column))
                    {
                        itemData.HDRDOCKEY = itemPrintApiReader.GetInt32(column);
                    }
                    column = itemPrintApiReader.GetOrdinal("usersession");
                    if (!itemPrintApiReader.IsDBNull(column))
                    {
                        itemData.USERSESSION = itemPrintApiReader.GetString(column);
                    }

                    column = itemPrintApiReader.GetOrdinal("hdrverkey");
                    if (!itemPrintApiReader.IsDBNull(column))
                    {
                        itemData.HDRVERKEY = itemPrintApiReader.GetInt32(column);
                    }

                    column = itemPrintApiReader.GetOrdinal("lineno");
                    if (!itemPrintApiReader.IsDBNull(column))
                    {
                        itemData.LINENO = itemPrintApiReader.GetInt32(column);
                    }

                    column = itemPrintApiReader.GetOrdinal("itemtext");
                    if (!itemPrintApiReader.IsDBNull(column))
                    {
                        itemData.ITEMTEXT = itemPrintApiReader.GetString(column);
                    }

                    column = itemPrintApiReader.GetOrdinal("pages");
                    if (!itemPrintApiReader.IsDBNull(column))
                    {
                        itemData.PAGES = itemPrintApiReader.GetInt32(column);
                    }

                    column = itemPrintApiReader.GetOrdinal("countpagetext");
                    if (!itemPrintApiReader.IsDBNull(column))
                    {
                        itemData.COUNTPAGETEXT = itemPrintApiReader.GetString(column);
                    }

                    column = itemPrintApiReader.GetOrdinal("page");
                    if (!itemPrintApiReader.IsDBNull(column))
                    {
                        itemData.PAGE = itemPrintApiReader.GetInt32(column);
                    }

                    column = itemPrintApiReader.GetOrdinal("pageoffset");
                    if (!itemPrintApiReader.IsDBNull(column))
                    {
                        itemData.PAGEOFFSET = itemPrintApiReader.GetInt32(column);
                    }

                    column = itemPrintApiReader.GetOrdinal("pagetotal");
                    if (!itemPrintApiReader.IsDBNull(column))
                    {
                        itemData.PAGETOTAL = itemPrintApiReader.GetDecimal(column);
                    }

                    column = itemPrintApiReader.GetOrdinal("pagetotal_string");
                    if (!itemPrintApiReader.IsDBNull(column))
                    {
                        itemData.PAGETOTAL_STRING = itemPrintApiReader.GetString(column);
                    }

                    itemForm.ITEMLIST.Add(itemData);
                }
            }
        }
    }
}