using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Genesis.Domain.Models;

public interface IConverter<T>
{
    T Convert();
}
