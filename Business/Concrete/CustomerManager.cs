using Business.Abstract;
using Business.Constants;
using Castle.Core.Resource;
using Core.Utilities.Results;
using DataAccesss.Abstract;
using DataAccesss.Concrete.EntityFramework;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete
{
    public class CustomerManager : ICustomerService
    {
        ICustomerDal _customerDal;

        public CustomerManager(ICustomerDal customerDal)
        {
            _customerDal = customerDal;
        }

        public IResult AddCustomer(Customer customer)
        {
            if (customer.CompanyName.Length <= 2)
            {
                return new ErrorResult(Messages.CompanyNameİnvalid);
            }
            _customerDal.Add(customer);
            return new Result(true, Messages.CustomerAdded);
        }

        
        public IResult DeleteCustomer(int id)
        {
            _customerDal.Delete(id);
            return new Result(true, Messages.DeleteCustomer);
        }

        public IDataResult<List<Customer>> GetAll()
        {
            return new SuccessDataResult<List<Customer>>(_customerDal.GetAll(), Messages.ListedCustomer);
        }

        public IDataResult<Customer> GetById(int id)
        {

            return new SuccessDataResult<Customer>(_customerDal.Get(cr => cr.Id == id));
        }

        public IResult UpdateCustomer(Customer customer)
        {
            _customerDal.Update(customer);
            return new Result(true, Messages.CustomerUpdated);
        }
    }
}
