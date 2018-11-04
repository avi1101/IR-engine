using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IR_engine
{
    /// <summary>
    /// this class implements a "document" object that separetes between the different fields of the document
    /// </summary>
    public class document
    {
        private string doc;
        private string docID;
        private string docDate;
        private string docHead;
        //private string docCity;

        /// <summary>
        /// this is the empty (default) constructor
        /// </summary>
        public document()
        {
            this.doc = null;
            this.docID = null;
            this.docDate = null;
            this.docHead = null;
            //this.docCity = null;
        }
        /// <summary>
        /// this is another constructor that takes all the fields
        /// </summary>
        /// <param name="doc"> the text part of the document</param>
        /// <param name="docId">the ID of the document</param>
        /// <param name="docDate"> the date that the document was created</param>
        /// <param name="docHead">the header of the document</param>
        public document(string doc, string docId, string docDate, string docHead,/*string docCity*/)
        {
            this.doc = doc;
            this.docID = docId;
            this.docDate = docDate;
            this.docHead = docHead;
            //this.docCity = docCity;
        }

        public void Setdoc(string doc)
        {
            this.doc = doc;
        }

        public void Setdocid(string docID)
        {
            this.docID = docID;
        }

        public void Setdoctime(string docDate)
        {
            this.docDate = docDate;
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

        public string getdocdate(string docDate)
        {
            return this.docDate;
        }
        public string getdochead(string docHead)
        {
            return this.docHead;
        }
       /* public void setdocCity(string docCity)
        {
            this.docCity = docCity;
        }
        public string getdocCity()
        {
            return this.docCity;
        }*/
    }
}
