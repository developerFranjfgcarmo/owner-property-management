namespace OwnerPropertyManagement.Domain.Mapper
{
    public static class MappingExtensions
    {
        /// <summary>
        ///     Extension method to map this object type into destination type.
        /// </summary>
        /// <typeparam name="TDest"></typeparam>
        /// <param name="src"></param>
        /// <returns></returns>
        public static TDest MapTo<TDest>(this object src)
        {
            return ObjectMapper.Mapper.Map<TDest>(src);
        }
    }
}
