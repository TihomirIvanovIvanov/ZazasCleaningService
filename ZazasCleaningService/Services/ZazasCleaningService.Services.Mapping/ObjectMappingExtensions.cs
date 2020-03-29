namespace ZazasCleaningService.Services.Mapping
{
    using System;

    public static class ObjectMappingExtensions
    {
        public static T To<T>(this object source)
        {
            if (source == null)
            {
                throw new ArgumentNullException(nameof(source));
            }

            return AutoMapperConfig.MapperInstance.Map<T>(source);
        }
    }
}
