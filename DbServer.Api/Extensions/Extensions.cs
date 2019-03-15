using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DbServer.Api.Extentions
{
    public static class ObjectExtensions
    {


        public static TDestino Mapear<TOrigem, TDestino>(this TOrigem objetoOriginal, IMapper mapper)
           where TDestino : class
           where TOrigem : class
        {
            return mapper.Map<TDestino>(objetoOriginal);
        }



    }
}
