using Microsoft.OData.Edm;
using Microsoft.OData.ModelBuilder;

namespace GenericOData.Application.Models.V1.EdmModel
{
    public static class GenerateEdmModel
    {
        public static IEdmModel GetEdmModel()
        {
            ODataConventionModelBuilder builder = new();
			builder.EntitySet<DataModels.edge>("edge");
			builder.EntitySet<DataModels.endpoint>("endpoint");
			builder.EntitySet<DataModels.o>("os");
			builder.EntitySet<DataModels.parameter>("parameter");
			builder.EntitySet<DataModels.protocol>("protocol");
			builder.EntitySet<DataModels.site>("site");
			builder.EntitySet<DataModels.uom>("uom");
            return builder.GetEdmModel();
        }
    }
}



