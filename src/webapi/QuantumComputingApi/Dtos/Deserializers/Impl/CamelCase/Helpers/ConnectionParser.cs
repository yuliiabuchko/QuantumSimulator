using QuantumComputingApi.Dtos.Impl.CamelCase.Helpers;
using System.Collections.Generic;
using System;

namespace QuantumComputingApi.Dtos.Deserializers.Impl.CamelCase.Helpers
{
    public class ConnectionParser
    {
        public IConnectionDto ParseConnection(dynamic dynamicConnection) {
                List<int?> mappedLeft = new List<int?>();
                var index = 0;
                var left = dynamicConnection.leftEntries;

                while(true) {
                    try{
                        int? mappedEntry = left[index];
                        mappedLeft.Add(mappedEntry);
                        index++;
                    }catch(Exception){
                        break;
                    }
                }


                List<int?> mappedRight = new List<int?>();
                index = 0;
                var right = dynamicConnection.rightEntries;

                while(true) {
                    try{
                        int? mappedEntry = right[index];
                        mappedRight.Add(mappedEntry);
                        index++;
                    }catch(Exception){
                        break;
                    }
                }
            return new ConnectionDto() {
                IdLeft = dynamicConnection.idLeft,
                IdRight = dynamicConnection.idRight,
                LeftEntries = mappedLeft,
                RightEntries = mappedRight
            };
        }
    }
}