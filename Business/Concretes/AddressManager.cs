using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using Business.Abstracts;
using Business.DTOs.Request.Address;
using Business.DTOs.Response.Address;
using Business.Rules;
using Core.DataAccess.Paging;
using DataAccess.Abstracts;
using Entities.Concretes;
using Entities.Concretes.Profiles;

namespace Business.Concretes
{
    public class AddressManager : IAddressService
    {
        IAddressDal _blogDal;
        IMapper _mapper;
        AddressBusinessRules _businessRules;

        public AddressManager(AddressBusinessRules businessRules, IAddressDal blogDal, IMapper mapper)
        {
            _businessRules = businessRules;
            _blogDal = blogDal;
            _mapper = mapper;
        }

        public async Task<CreatedAddressResponse> Add(CreateAddressRequest createAddressRequest)
        {
            Address blog = _mapper.Map<Address>(createAddressRequest);
            Address createdAddress = await _blogDal.AddAsync(blog);
            CreatedAddressResponse createdAddressResponse = _mapper.Map<CreatedAddressResponse>(createdAddress);
            return createdAddressResponse;
        }

        public async Task<DeletedAddressResponse> Delete(DeleteAddressRequest deleteAddressRequest)
        {
            var data = await _blogDal.GetAsync(i => i.Id == deleteAddressRequest.Id);
            _mapper.Map(deleteAddressRequest, data);
            data.DeletedDate = DateTime.Now;
            var result = await _blogDal.DeleteAsync(data, true);
            var result2 = _mapper.Map<DeletedAddressResponse>(result);
            return result2;
        }

        public async Task<CreatedAddressResponse> GetById(int id)
        {
            var result = await _blogDal.GetAsync(c => c.Id == id);
            Address mappedAddress = _mapper.Map<Address>(result);
            CreatedAddressResponse createdAddressResponse = _mapper.Map<CreatedAddressResponse>(mappedAddress);
            return createdAddressResponse;
        }


        public async Task<IPaginate<GetListAddressResponse>> GetListAsync(PageRequest pageRequest)
        {
            var data = await _blogDal.GetListAsync(
                index: pageRequest.PageIndex,
                size: pageRequest.PageSize
            );
            var result = _mapper.Map<Paginate<GetListAddressResponse>>(data);
            return result;
        }


        public async Task<UpdatedAddressResponse> Update(UpdateAddressRequest updateAddressRequest)
        {
            var data = await _blogDal.GetAsync(i => i.Id == updateAddressRequest.Id);
            _mapper.Map(updateAddressRequest, data);
            data.UpdatedDate = DateTime.Now;
            await _blogDal.UpdateAsync(data);
            var result = _mapper.Map<UpdatedAddressResponse>(data);
            return result;
        }
    }
}
