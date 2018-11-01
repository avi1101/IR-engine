using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IR_engine
{
    class document
    {
        private string doc;
        private string docID;
        private string docTime;
        private string docHead;

        public document()
        {
            this.doc = null;
            this.docID = null;
            this.docTime = null;
            this.docHead = null;
        }

        public document(string doc, string docId, string docTime, string docHead)
        {
            this.doc = doc;
            this.docID = docId;
            this.docTime = docTime;
            this.docHead = docHead;
        }

        public void Setdoc(string doc)
        {
            this.doc = doc;
        }

        public void Setdocid(string docID)
        {
            this.docID = docID;
        }

        public void Setdoctime(string docTime)
        {
            this.docTime = docTime;
        }
        public void Setdochead(string docHead)
        {
            this.docHead = docHead;
        }

        public string getdoc()
        {
            return this.doc;
        }

        public string getdocid()
        {
            return this.docID;
        }

        public string getdoctime(string docTime)
        {
            return this.docTime;
        }
        public string getdochead(string docHead)
        {
            return this.docHead;
        }
    }
}
