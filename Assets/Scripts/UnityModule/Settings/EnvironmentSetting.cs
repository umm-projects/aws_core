
using System.Collections.Generic;
using System.Linq;
using Amazon;
using UnityEngine;

namespace UnityModule.Settings {

    public partial class EnvironmentSetting {

        // ReSharper disable once PartialTypeWithSinglePart
        [System.Serializable]
        public partial class EnvironmentSetting_AWS {

            private enum Region {
                Undefined = 0,
                USEast1,
                USEast2,
                USWest1,
                USWest2,
                EUWest1,
                EUWest2,
                EUCentral1,
                APNortheast1,
                APNortheast2,
                APSouth1,
                APSoutheast1,
                APSoutheast2,
                SAEast1,
                USGovCloudWest1,
                CNNorth1,
                CACentral1,
            }

            private static readonly Dictionary<Region, RegionEndpoint> regionEndpointMap = new Dictionary<Region, RegionEndpoint>() {
                { Region.USEast1        , RegionEndpoint.USEast1 },
                { Region.USEast2        , RegionEndpoint.USEast2 },
                { Region.USWest1        , RegionEndpoint.USWest1 },
                { Region.USWest2        , RegionEndpoint.USWest2 },
                { Region.EUWest1        , RegionEndpoint.EUWest1 },
                { Region.EUWest2        , RegionEndpoint.EUWest2 },
                { Region.EUCentral1     , RegionEndpoint.EUCentral1 },
                { Region.APNortheast1   , RegionEndpoint.APNortheast1 },
                { Region.APNortheast2   , RegionEndpoint.APNortheast2 },
                { Region.APSouth1       , RegionEndpoint.APSouth1 },
                { Region.APSoutheast1   , RegionEndpoint.APSoutheast1 },
                { Region.APSoutheast2   , RegionEndpoint.APSoutheast2 },
                { Region.SAEast1        , RegionEndpoint.SAEast1 },
                { Region.USGovCloudWest1, RegionEndpoint.USGovCloudWest1 },
                { Region.CNNorth1       , RegionEndpoint.CNNorth1 },
                { Region.CACentral1     , RegionEndpoint.CACentral1 },
            };

            [SerializeField]
            private Region baseRegion;

            public RegionEndpoint RegionEndpoint {
                get {
                    if (regionEndpointMap.ContainsKey(this.baseRegion)) {
                        return regionEndpointMap[this.baseRegion];
                    }
                    return null;
                }
                set {
                    if (regionEndpointMap.ContainsValue(value)) {
                        this.baseRegion = regionEndpointMap.Where(x => x.Value == value).Select(x => x.Key).FirstOrDefault();
                    } else {
                        this.baseRegion = Region.Undefined;
                    }
                }
            }

        }

        [SerializeField]
        private EnvironmentSetting_AWS amazonWebServices;

        public EnvironmentSetting_AWS AmazonWebServices {
            get {
                return this.amazonWebServices;
            }
            set {
                this.amazonWebServices = value;
            }
        }

    }

}