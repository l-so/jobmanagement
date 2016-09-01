using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace JobManagement.WebMvc.Models.GL
{
    public class GLIndexModel
    {
        public List<EFDataModel.GLAccount> GLAccounts { get; set; }
        static int lastLength = 0;
        static int indent = -1;
        public void loadModelData()
        {
            GLAccounts = DataAccessLayer.DBGeneralLedger.getGLAccounts();
        }

        public string Indent(EFDataModel.GLAccount a)
        {
            string r = string.Empty;
            int l = a.GLAccountCode.Length;
            if (l > lastLength)
            {
                indent += 1;
                lastLength = l;
            }
            if (l < lastLength)
            {
                indent -= 1;
                lastLength = l;
            }
            if (l < 4)
            {
                indent = 0;
                lastLength = l;
            }
            r = (indent * 12).ToString();
            return r;
        }
    }
}