using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLySach
{
    class Book
    {
        string name,author,category,year,code;
        int amount;
        float price;

        public Book(string name,string author, string category ,string year, float price, int amount,string code) {
            this.name = name;
            this.author = author;
            this.category = category;
            this.year = year;
            this.price = price;
            this.amount = amount;
            this.code = code;
        }
        
        public Dictionary<string,string> getData()
        {
            Dictionary<string, string> retData = new Dictionary<string, string>();
            retData["name"] = name;
            retData["author"] = author;
            retData["category"] = category;
            retData["year"] = year;
            retData["price"] = price.ToString();
            retData["amount"] = amount.ToString();
            retData["code"] = code;
            return retData;
        }
        public bool changeData(string[] modificationInfo)
        {
            if (modificationInfo.Count() == 6)
            {
                for (int i = 0; i < 6; i++)
                {
                    switch (i)
                    {
                        case 0:
                            if (modificationInfo[i] != "")
                            {
                                this.name = modificationInfo[i];
                            }
                            break;

                        case 1:
                            if (modificationInfo[i] != "")
                            {
                                this.author = modificationInfo[i];
                            }
                            break;

                        case 2:
                            if (modificationInfo[i] != "")
                            {
                                this.category = modificationInfo[i];
                            }
                            break;

                        case 3:
                            if (modificationInfo[i] != "")
                            {
                                this.year = modificationInfo[i];
                            }
                            break;

                        case 4:
                            if (modificationInfo[i] != "")
                            {
                                this.price = float.Parse(modificationInfo[i]);
                            }
                            break;

                        case 5:
                            if (modificationInfo[i] != "")
                            {
                                this.amount = Convert.ToInt32(modificationInfo[i]);
                            }
                            break;
                        case 6:
                            if (modificationInfo[i] != "") {
                                this.code = modificationInfo[i];
                            }
                            break;
                    }
                }
                return true;
            }
            return false;
        }
        public bool isMe(string input) {
            input = input.ToLower();
            try
            {
                int inputAmount = Convert.ToInt32(input);
                if (amount == inputAmount)
                    return true;
                else
                    throw new InvalidCastException();
            }
            catch {
                try
                {
                    float inputPrice = float.Parse(input);
                    if (price == inputPrice)
                        return true;                    
                }
                catch
                {
                    if (name.ToLower().Contains(input) || author.ToLower().Contains(input) || category.ToLower().Contains(input) || year.ToLower().Contains(input)||code.Contains(input))
                        return true;
                }
            }
            return false;
        }

    }
}
