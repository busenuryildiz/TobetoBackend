using AutoMapper;
using Business.Abstracts;
using Business.DTOs.Request.Certificate;
using Business.DTOs.Response.Certificate;
using Business.Rules;
using Core.DataAccess.Paging;
using DataAccess.Abstracts;
using Entities.Concretes;
using Entities.Concretes.Profiles;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concretes
{
    public class CertificateManager : ICertificateService
    {
        ICertificateDal _certificateDal;
        IMapper _mapper;
        CertificateBusinessRules _businessRules;

        public CertificateManager(CertificateBusinessRules businessRules, ICertificateDal certificateDal, IMapper mapper)
        {
            _businessRules = businessRules;
            _certificateDal = certificateDal;
            _mapper = mapper;
        }

        public async Task<CreatedCertificateResponse> Add(CreateCertificateRequest createCertificateRequest)
        {
            Certificate certificate = _mapper.Map<Certificate>(createCertificateRequest);
            Certificate createdCertificate = await _certificateDal.AddAsync(certificate);
            CreatedCertificateResponse createdCertificateResponse = _mapper.Map<CreatedCertificateResponse>(createdCertificate);
            return createdCertificateResponse;
        }

        public async Task<DeletedCertificateResponse> Delete(DeleteCertificateRequest deleteCertificateRequest)
        {
            var data = await _certificateDal.GetAsync(i => i.Id == deleteCertificateRequest.Id);
            _mapper.Map(deleteCertificateRequest, data);
            data.DeletedDate = DateTime.Now;
            var result = await _certificateDal.DeleteAsync(data, true);
            var result2 = _mapper.Map<DeletedCertificateResponse>(result);
            return result2;
        }

        public async Task<CreatedCertificateResponse> GetById(int id)
        {
            var result = await _certificateDal.GetAsync(c => c.Id == id);
            Certificate mappedCertificate = _mapper.Map<Certificate>(result);

            CreatedCertificateResponse createdCertificateResponse = _mapper.Map<CreatedCertificateResponse>(mappedCertificate);

            return createdCertificateResponse;
        }


        public async Task<IPaginate<GetListCertificateResponse>> GetListAsync(PageRequest pageRequest)
        {
            var data = await _certificateDal.GetListAsync(
                index: pageRequest.PageIndex,
                size: pageRequest.PageSize
            );
            var result = _mapper.Map<Paginate<GetListCertificateResponse>>(data);
            return result;
        }


        public async Task<UpdatedCertificateResponse> Update(UpdateCertificateRequest updateCertificateRequest)
        {
            var data = await _certificateDal.GetAsync(i => i.Id == updateCertificateRequest.Id);
            _mapper.Map(updateCertificateRequest, data);
            data.UpdatedDate = DateTime.Now;
            await _certificateDal.UpdateAsync(data);
            var result = _mapper.Map<UpdatedCertificateResponse>(data);
            return result;
        }
    }
}
