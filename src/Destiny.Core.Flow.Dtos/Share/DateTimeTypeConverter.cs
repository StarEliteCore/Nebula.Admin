using AutoMapper;
using System;
using System.Collections.Generic;
using System.Text;

namespace Destiny.Core.Flow.Dtos.Share
{
    public class DateTimeTypeConverter : ITypeConverter<DateTime, DateTimeOffset>, ITypeConverter<DateTimeOffset, DateTime>
    {
        public DateTime Convert(DateTimeOffset source, DateTime destination, ResolutionContext context)
        {
            return source.LocalDateTime;
        }

        public DateTimeOffset Convert(DateTime source, DateTimeOffset destination, ResolutionContext context)
        {
            return new DateTimeOffset(source);
        }
    }
}
