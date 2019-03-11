using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;

namespace AppliFraisWebService
{
    // REMARQUE : vous pouvez utiliser la commande Renommer du menu Refactoriser pour changer le nom de classe "Service1" dans le code, le fichier svc et le fichier de configuration.
    // REMARQUE : pour lancer le client test WCF afin de tester ce service, sélectionnez Service1.svc ou Service1.svc.cs dans l'Explorateur de solutions et démarrez le débogage.
    public class Service1 : IService1
    {
        public string GetData(int value)
        {
            return string.Format("You entered: {0}", value);
        }

        public CompositeType GetDataUsingDataContract(CompositeType composite)
        {
            if (composite == null)
            {
                throw new ArgumentNullException("composite");
            }
            if (composite.BoolValue)
            {
                composite.StringValue += "Suffix";
            }
            return composite;
        }

        public List<Models.Visiteur> ModifUtilisateur(string request)
        {
            List<Models.Visiteur> listVis = new List<Models.Visiteur>();
            BaseDonne.gsb_fraisEntities db = new BaseDonne.gsb_fraisEntities();
            foreach (BaseDonne.visiteur item in db.visiteur.ToList())
            {
                listVis.Add(new Models.Visiteur() { Nom = item.nom });
            }
            //db.visiteur.Add();
            BaseDonne.visiteur vis = db.visiteur.Where(v => v.id == "a001").FirstOrDefault();
            vis.nom = request;
            db.SaveChanges();
            return listVis;
        }
    }
}
