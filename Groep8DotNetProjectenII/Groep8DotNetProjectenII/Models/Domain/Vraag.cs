using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Web;
using Groep8DotNetProjectenII.Models.Domain;

namespace DeterminerenTest.Models.Domein
{
    public class Vraag
    {
        public int VraagId { get; set; }
        public virtual Parameter Parameter { get; set; }
        public virtual VraagOperator Operator { get; set; }
        public double Waarde { get; set; }

        public virtual Parameter Parameter2 { get; set; }


        public Vraag(Parameter parameter, VraagOperator @operator, double waarde)
        {
            Parameter = parameter;
            Operator = @operator;
            Waarde = waarde;
        }

        public Vraag(Parameter parameter, VraagOperator @operator, Parameter parameter2)
        {
            Parameter = parameter;
            Operator = @operator;
            Parameter2 = parameter2;
        }

        public virtual bool Antwoord(Klimatogram klimatogram)
        {
            switch (Operator)
            {
                case VraagOperator.Equal:
                    return Parameter2 == null ? 
                        Parameter.GetWaarde(klimatogram) == Waarde : 
                        Parameter.GetWaarde(klimatogram) == Parameter2.GetWaarde(klimatogram);
                    
                case VraagOperator.GreaterThan: return Parameter2 == null ?
                     Parameter.GetWaarde(klimatogram) > Waarde :
                     Parameter.GetWaarde(klimatogram) > Parameter2.GetWaarde(klimatogram);

                case VraagOperator.GreaterThanOrEqual: return Parameter2 == null ?
                       Parameter.GetWaarde(klimatogram) >= Waarde :
                       Parameter.GetWaarde(klimatogram) >= Parameter2.GetWaarde(klimatogram);

                case VraagOperator.LessThan: return Parameter2 == null ?
                     Parameter.GetWaarde(klimatogram) < Waarde :
                     Parameter.GetWaarde(klimatogram) < Parameter2.GetWaarde(klimatogram);

                  case VraagOperator.LessThanOrEqual:  return Parameter2 == null ?
                        Parameter.GetWaarde(klimatogram) <= Waarde :
                        Parameter.GetWaarde(klimatogram) <= Parameter2.GetWaarde(klimatogram);
            }
            throw new Exception("Vraag niet correct opgesteld");
        }

        [ExcludeFromCodeCoverage]
        public Vraag()
        {
            
        }

        public override string ToString()
        {

            return Parameter.Code + " " + getOperatorString() + " " +
                   (Parameter2 == null ? "" + Waarde : Parameter2.Code);
        }

        private string getOperatorString()
        {
            switch (Operator)
            {
                case VraagOperator.Equal:
                    return "=";

                case VraagOperator.GreaterThan:
                    return ">";

                case VraagOperator.GreaterThanOrEqual:
                    return ">=";

                case VraagOperator.LessThan:
                    return "<";

                case VraagOperator.LessThanOrEqual:
                    return "<=";

            }
            return "";
        }
    }
}