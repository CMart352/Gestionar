using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UserRoles.Models;
using UserRoles.Models.FormsViewModels;
using UserRoles.Models.ViewModels;

namespace UserRoles.Helpers
{
    public static class Utils
    {

        public static T GetModel<T>(this object objviewmodel) where T : new()
        {
            T objmodel = new T();

            if (objmodel is Persona) {
                ((Persona)(object)objmodel).PersonId = ((PersonaFormViewModel)(object)objviewmodel).PersonId;
                ((Persona)(object)objmodel).Street = ((PersonaFormViewModel)(object)objviewmodel).Street;
                ((Persona)(object)objmodel).Numero = ((PersonaFormViewModel)(object)objviewmodel).Numero;
                ((Persona)(object)objmodel).Floor = ((PersonaFormViewModel)(object)objviewmodel).Floor;
                ((Persona)(object)objmodel).Aparment = ((PersonaFormViewModel)(object)objviewmodel).Aparment;
                ((Persona)(object)objmodel).Zip = ((PersonaFormViewModel)(object)objviewmodel).Zip;
                ((Persona)(object)objmodel).CityId = ((PersonaFormViewModel)(object)objviewmodel).City;
                ((Persona)(object)objmodel).Email = ((PersonaFormViewModel)(object)objviewmodel).Email;
                ((Persona)(object)objmodel).HomePhone = ((PersonaFormViewModel)(object)objviewmodel).HomePhone;
                ((Persona)(object)objmodel).CellPhone = ((PersonaFormViewModel)(object)objviewmodel).CellPhone;
                ((Persona)(object)objmodel).TypoDocumento = ((PersonaFormViewModel)(object)objviewmodel).TypoDocumento;
                ((Persona)(object)objmodel).NumeroDoc = ((PersonaFormViewModel)(object)objviewmodel).NumeroDoc;
                ((Persona)(object)objmodel).Atm = ((PersonaFormViewModel)(object)objviewmodel).Atm;
                ((Persona)(object)objmodel).Location = ((PersonaFormViewModel)(object)objviewmodel).Location;
                ((Persona)(object)objmodel).WorkingCapital = ((PersonaFormViewModel)(object)objviewmodel).WorkingCapital;

                if (objmodel is PersonaFisica && objviewmodel is PersonaFormViewModel)
                {
                    ((PersonaFisica)(object)objmodel).FirstName = ((PersonaFormViewModel)(object)objviewmodel).FirstName;
                    ((PersonaFisica)(object)objmodel).SecondName = ((PersonaFormViewModel)(object)objviewmodel).SecondName;
                    ((PersonaFisica)(object)objmodel).FirstLastName = ((PersonaFormViewModel)(object)objviewmodel).FirstLastName;
                    ((PersonaFisica)(object)objmodel).SecondLastName = ((PersonaFormViewModel)(object)objviewmodel).SecondLastName;
                   
                }
                else if (objmodel is PersonaJuridica && objviewmodel is PersonaFormViewModel)
                {
                    ((PersonaJuridica)(object)objmodel).RazonSocial = ((PersonaFormViewModel)(object)objviewmodel).RazonSocial;
                    //((PersonaJuridica)(object)objmodel).Atm = ((PersonaFormViewModel)(object)objviewmodel).Atm;
                    //((PersonaJuridica)(object)objmodel).Location = ((PersonaFormViewModel)(object)objviewmodel).Location;
                    //((PersonaJuridica)(object)objmodel).WorkingCapital = ((PersonaFormViewModel)(object)objviewmodel).WorkingCapital;

                }
            }
            return objmodel;
        }

        public static T GetViewModel<T>(this object objmodel) where T : new()
        {
            T objviewmodel = new T();

            if(objmodel is Persona)
            {
                ((PersonaDetailViewModel)(object)objviewmodel).PersonId = ((Persona)(object)objmodel).PersonId;
                ((PersonaDetailViewModel)(object)objviewmodel).Street = ((Persona)(object)objmodel).Street;
                ((PersonaDetailViewModel)(object)objviewmodel).Numero = ((Persona)(object)objmodel).Numero;
                ((PersonaDetailViewModel)(object)objviewmodel).Zip = ((Persona)(object)objmodel).Zip;
                ((PersonaDetailViewModel)(object)objviewmodel).CityId = ((Persona)(object)objmodel).CityId;
                ((PersonaDetailViewModel)(object)objviewmodel).Email = ((Persona)(object)objmodel).Email;
                ((PersonaDetailViewModel)(object)objviewmodel).HomePhone = ((Persona)(object)objmodel).HomePhone;
                ((PersonaDetailViewModel)(object)objviewmodel).CellPhone = ((Persona)(object)objmodel).CellPhone;
                ((PersonaDetailViewModel)(object)objviewmodel).TypoDocumento = ((Persona)(object)objmodel).TypoDocumento;
                ((PersonaDetailViewModel)(object)objviewmodel).NumeroDoc = ((Persona)(object)objmodel).NumeroDoc;
                ((PersonaDetailViewModel)(object)objviewmodel).Atm = ((Persona)(object)objmodel).Atm;
                ((PersonaDetailViewModel)(object)objviewmodel).Location = ((Persona)(object)objmodel).Location;
                ((PersonaDetailViewModel)(object)objviewmodel).WorkingCapital = ((Persona)(object)objmodel).WorkingCapital;

                if (objmodel is PersonaFisica && objviewmodel is PersonaDetailViewModel)
                {
                    ((PersonaDetailViewModel)(object)objviewmodel).FirstName = ((PersonaFisica)(object)objmodel).FirstName;
                    ((PersonaDetailViewModel)(object)objviewmodel).SecondName = ((PersonaFisica)(object)objmodel).SecondName;
                    ((PersonaDetailViewModel)(object)objviewmodel).FirstLastName = ((PersonaFisica)(object)objmodel).FirstLastName;
                    ((PersonaDetailViewModel)(object)objviewmodel).SecondLastName = ((PersonaFisica)(object)objmodel).SecondLastName;
                    //((PersonaDetailViewModel)(object)objmodel).Street = ((PersonaFisica)(object)objviewmodel).Street;
                    //((PersonaDetailViewModel)(object)objmodel).Numero = ((PersonaFisica)(object)objviewmodel).Numero;
                    //((PersonaFisica)(object)objmodel).Floor = ((PersonaFormViewModel)(object)objviewmodel).Floor;
                    //((PersonaFisica)(object)objmodel).Aparment = ((PersonaFormViewModel)(object)objviewmodel).Aparment;
                    //((PersonaFisica)(object)objmodel).Zip = ((PersonaFormViewModel)(object)objviewmodel).Zip;
                    //((PersonaFisica)(object)objmodel).CityId = ((PersonaFormViewModel)(object)objviewmodel).City;
                    //((PersonaFisica)(object)objmodel).Email = ((PersonaFormViewModel)(object)objviewmodel).Email;

                }
                else if (objmodel is PersonaJuridica && objviewmodel is PersonaDetailViewModel)
                {
                    ((PersonaFormViewModel)(object)objviewmodel).RazonSocial = ((PersonaJuridica)(object)objmodel).RazonSocial;
                    

                }
            }
         
            return objviewmodel;
        }
    }
}
