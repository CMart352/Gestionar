using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace UserRoles.Models.FormsViewModels
{
    public class CustomEnums
    {
        public enum TypoDocumentoEnum
        {
            [Display(Name = "--Select--")]
            Select = 0,
            CUIT = 1,
            CUIL = 2,
            CDI = 3
        }

        public enum TypoRepresentanteEnum
        {
            [Display(Name = "--Select--")]
            Select = 0,
            Legal = 1,
            Apoderado = 2
        }

        public enum TypoPersonaEnum
        {
            [Display(Name = "--Select--")]
            //Select = 0,
            Fisica = 0,
            Juridica = 1
        }

        public enum TypoClienteEnum
        {
            Atm= 0,
            WorkingCapital = 1,
            Location = 2
        }

        public enum TypoStatusClienteEnum
        {
            Pending = 0,
            Aproved = 1,
            Denied = 2
        }
        public enum TypoClienteWCEnum
        {
            Inversionista = 0,
            DescargaFactura = 1          
        }

    }
}
