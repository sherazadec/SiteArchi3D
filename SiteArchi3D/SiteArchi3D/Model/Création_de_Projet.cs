//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace SiteArchi3D.Model
{
    using System;
    using System.Collections.Generic;
    
    public partial class Création_de_Projet
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Création_de_Projet()
        {
            this.QuestionnaireProjet = new HashSet<QuestionnaireProjet>();
        }
    
        public int id { get; set; }
        public int xidProjet { get; set; }
        public int xidPromoteur { get; set; }
        public int Prestataires { get; set; }
        public string Questionnaire { get; set; }
        public string uploadfichiers { get; set; }
    
        public virtual Liste_de_Prestataires Liste_de_Prestataires { get; set; }
        public virtual Projet Projet { get; set; }
        public virtual Promoteur Promoteur { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<QuestionnaireProjet> QuestionnaireProjet { get; set; }
    }
}
