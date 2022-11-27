
namespace MilitaryElite.Models
{
    using Interface;

    using System.Collections.Generic;
    using System.Text;

    public class LieutenantGeneral : Private, ILeutenantGeneral
    {
        private readonly ICollection<IPrivate> privates;

        public LieutenantGeneral(int id, string firstName, string lastName,
            decimal salary,ICollection<IPrivate> privates)
            : base(id, firstName, lastName, salary)
        {
            this.privates = privates;
        }

        public IReadOnlyCollection<IPrivate> Privates
            => (IReadOnlyCollection<IPrivate>)privates;

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine(base.ToString())
                .AppendLine($"Privates:");
            foreach (var pr in Privates)
            {
                sb.AppendLine(pr.ToString());
            }

            return sb.ToString().TrimEnd();
        }
    }
}
