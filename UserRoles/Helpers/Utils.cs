using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UserRoles.Models;
using UserRoles.Models.FormsViewModels;

namespace UserRoles.Helpers
{
    public static class Utils
    {

        public static T GetModel<T>(this object objviewmodel) where T : new()
        {
            T objmodel = new T();


            if (objmodel is PersonaFisica && objviewmodel is PersonaFormViewModel)
            {
                ((PersonaFisica)(object)objmodel).PersonId = ((PersonaFormViewModel)(object)objviewmodel).PersonId;
                ((PersonaFisica)(object)objmodel).Street = ((PersonaFormViewModel)(object)objviewmodel).Street;
                ((PersonaFisica)(object)objmodel).Numero = ((PersonaFormViewModel)(object)objviewmodel).Numero;
                ((PersonaFisica)(object)objmodel).Floor = ((PersonaFormViewModel)(object)objviewmodel).Floor;
                ((PersonaFisica)(object)objmodel).Aparment = ((PersonaFormViewModel)(object)objviewmodel).Aparment;
                ((PersonaFisica)(object)objmodel).Zip = ((PersonaFormViewModel)(object)objviewmodel).Zip;
                ((PersonaFisica)(object)objmodel).CityId = ((PersonaFormViewModel)(object)objviewmodel).City;
                ((PersonaFisica)(object)objmodel).Email = ((PersonaFormViewModel)(object)objviewmodel).Email;
                ((PersonaFisica)(object)objmodel).HomePhone = ((PersonaFormViewModel)(object)objviewmodel).HomePhone;
                ((PersonaFisica)(object)objmodel).CellPhone = ((PersonaFormViewModel)(object)objviewmodel).CellPhone;
                ((PersonaFisica)(object)objmodel).TypoDocumento = ((PersonaFormViewModel)(object)objviewmodel).TypoDocumento;
                ((PersonaFisica)(object)objmodel).NumeroDoc = ((PersonaFormViewModel)(object)objviewmodel).NumeroDoc;
                ((PersonaFisica)(object)objmodel).FirstName = ((PersonaFormViewModel)(object)objviewmodel).FirstName;
                ((PersonaFisica)(object)objmodel).SecondName = ((PersonaFormViewModel)(object)objviewmodel).SecondName;
                ((PersonaFisica)(object)objmodel).FirstLastName = ((PersonaFormViewModel)(object)objviewmodel).FirstLastName;
                ((PersonaFisica)(object)objmodel).SecondLastName = ((PersonaFormViewModel)(object)objviewmodel).SecondLastName;
                ((PersonaFisica)(object)objmodel).TypoPersona = ((PersonaFormViewModel)(object)objviewmodel).TypoPersona;
            }
            else if (objmodel is PersonaJuridica && objviewmodel is PersonaFormViewModel)
            {
                ((PersonaJuridica)(object)objmodel).PersonId = ((PersonaFormViewModel)(object)objviewmodel).PersonId;
                ((PersonaJuridica)(object)objmodel).Street = ((PersonaFormViewModel)(object)objviewmodel).Street;
                ((PersonaJuridica)(object)objmodel).Numero = ((PersonaFormViewModel)(object)objviewmodel).Numero;
                ((PersonaJuridica)(object)objmodel).Floor = ((PersonaFormViewModel)(object)objviewmodel).Floor;
                ((PersonaJuridica)(object)objmodel).Aparment = ((PersonaFormViewModel)(object)objviewmodel).Aparment;
                ((PersonaJuridica)(object)objmodel).Zip = ((PersonaFormViewModel)(object)objviewmodel).Zip;
                ((PersonaJuridica)(object)objmodel).CityId = ((PersonaFormViewModel)(object)objviewmodel).City;
                ((PersonaJuridica)(object)objmodel).Email = ((PersonaFormViewModel)(object)objviewmodel).Email;
                ((PersonaJuridica)(object)objmodel).HomePhone = ((PersonaFormViewModel)(object)objviewmodel).HomePhone;
                ((PersonaJuridica)(object)objmodel).CellPhone = ((PersonaFormViewModel)(object)objviewmodel).CellPhone;
                ((PersonaJuridica)(object)objmodel).RazonSocial = ((PersonaFormViewModel)(object)objviewmodel).RazonSocial;
                ((PersonaJuridica)(object)objmodel).TypoPersona = ((PersonaFormViewModel)(object)objviewmodel).TypoPersona;

            }
            return objmodel;
        }
    }
}


