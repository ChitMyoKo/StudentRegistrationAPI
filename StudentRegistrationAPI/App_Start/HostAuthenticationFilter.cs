using System.Web.Http.Filters;

namespace StudentRegistrationAPI.App_Start
{
    internal class HostAuthenticationFilter : IFilter
    {
        private object authenticationType;

        public HostAuthenticationFilter(object authenticationType)
        {
            this.authenticationType = authenticationType;
        }

        bool IFilter.AllowMultiple => throw new System.NotImplementedException();
    }
}