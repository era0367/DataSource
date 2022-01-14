using System;
using Common;
using Hl7.Fhir.Model;
using Newtonsoft.Json;
using ADL_FHIRGenerator;
using Newtonsoft.Json.Linq;
using System.Collections.Generic;

namespace XDSDataSource
{
    public class ADLGenerator
    {
        private static readonly String KEY_FOR_REGISTRY_OBJECT = "registryObjectList";
        private static readonly String KEY_FOR_DOCUMENT_LIST = "documentList";
        private static List<Observation> GetObservationList()
        {
            return ADL.GetAdlObservationList();
        }
        private static List<Metadata> GetMetadataList()
        {
            return ADL_MetaGenerator.Generator.GetMetadataList();
        }
        public static String GetITI41Request()
        {
            List<Observation> observationList = GetObservationList();
            List<Metadata> metadataList = GetMetadataList();
            JObject jObject = new JObject();
            JArray jArrayMetadata = new JArray();
            JArray jArrayFhir = new JArray();
            for(int i = 0; i < observationList.Count; i++)
            {
                jArrayFhir.Add(ADL.ToString(observationList[i]));
                jArrayMetadata.Add(ToJsonString(metadataList[i]));
            }
            jObject.Add(KEY_FOR_REGISTRY_OBJECT, jArrayMetadata);
            jObject.Add(KEY_FOR_DOCUMENT_LIST, jArrayFhir);
            return jObject.ToString();
        }
        private static String ToJsonString(Object data)
        {
            JsonSerializerSettings setting = new JsonSerializerSettings
            {
                NullValueHandling = NullValueHandling.Ignore
            };
            setting.Converters.Add(new Newtonsoft.Json.Converters.StringEnumConverter());
            return JsonConvert.SerializeObject(data, setting);
        }
    }
}
