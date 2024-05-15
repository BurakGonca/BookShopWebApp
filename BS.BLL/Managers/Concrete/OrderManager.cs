using BS.BLL.Managers.Abstract;
using BS.DAL.Services.Abstract;
using BS.DAL.Services.Concrete;
using BS.DTO.Concrete;
using BS.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BS.BLL.Managers.Concrete
{
	public class OrderManager : Manager<OrderDto, Order>
	{
		public OrderManager(OrderService service) : base(service)
		{
		}
	}
}
