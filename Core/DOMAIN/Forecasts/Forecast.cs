using System.Collections.Generic;
using Budget.Core;


namespace Budget.Core
{
    public class Forecast : Entity, IValidatableObject
    {
        public Forecast()
        {
            ForecastState = new ForecastStateNew();
        }
        public Forecast(ForecastFlow forecastFlow)
        {
            ForecastState.HandleState(this, forecastFlow);
        }
        public string name { get; set; }
        //implement STATE - pattern
        internal ForecastState ForecastState { get; set; }
        public void ChangeState(ForecastFlow forecastFlow)
        {
            // TODO : Before forecast's status will be changed to "Accepted", we might be careful,
            // TODO : another forecast with status "Accepted" must be changed to "Ready" status,
            // TODO : 'couse must be one forecast with status "Accepted"

            ForecastState.HandleState(this, forecastFlow);
        }
        public IEnumerable<DomainValidationResult>  Validate()
        {
            List<DomainValidationResult> errors = new List<DomainValidationResult>();
            // TODO: Validating implementation
            return errors;
        }
    }
}