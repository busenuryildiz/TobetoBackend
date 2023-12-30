using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Utilities.BusinessRulesEngine
{
    public class BusinessRulesEngine
    {

        public static bool Run(params bool[] logics)
        {

            foreach (bool logic in logics)
            {
                if (!logic)
                {
                    return false;
                }
            }
            return true;

        }

    }
}
