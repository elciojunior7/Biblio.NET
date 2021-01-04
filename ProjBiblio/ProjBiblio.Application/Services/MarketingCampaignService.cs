using System;
using System.Collections.Generic;
using AutoMapper;
using ProjBiblio.Application.InputModels;
using ProjBiblio.Application.Interfaces;
using ProjBiblio.Application.ViewModels;
using ProjBiblio.Domain.Entities;
using ProjBiblio.Domain.Interfaces;

namespace ProjBiblio.Application.Services
{
    public class MarketingCampaignService : IMarketingCampaignService
    {
        private IUnitOfWork _uow;
        private IMapper _mapper;

        public MarketingCampaignService(IUnitOfWork uow, IMapper mapper)
        {
             this._uow = uow;
             this._mapper = mapper;
        }

        public MarketingCampaignListViewModel Get()
        {
             var mkt = this._uow.MarketingCampaignRepository.Get();
             return new MarketingCampaignListViewModel()
             {
                MarketingCampaigns = _mapper.Map<IEnumerable<MarketingCampaignViewModel>>(mkt)
             };
        }

        public MarketingCampaignViewModel Get(int id)
        {
            var mkt = this._uow.MarketingCampaignRepository.GetById(m => m.MarketingCampaignID == id);
            return _mapper.Map<MarketingCampaignViewModel>(mkt);
        }

        public MarketingCampaignViewModel Post(MarketingCampaignInputModel mktInputModel)
        {
            var mkt = _mapper.Map<MarketingCampaign>(mktInputModel);
            mkt.StartDate = DateTime.Now;
            mkt.EndDate = DateTime.Now.AddDays(15);
            _uow.MarketingCampaignRepository.Add(mkt);
            _uow.Commit();

            return _mapper.Map<MarketingCampaignViewModel>(mkt);
        }

        public MarketingCampaignViewModel Put(int id, MarketingCampaignInputModel mktInputModel)
        {
            _uow.MarketingCampaignRepository.DeleteMarketingBooks(id);
            _uow.Commit();

            var mkt = _mapper.Map<MarketingCampaign>(mktInputModel);

            foreach (var bm in mkt.BoMarketing) {
                bm.Marketings = mkt;
            }

            mkt.StartDate = DateTime.Now;
            mkt.EndDate = DateTime.Now.AddDays(15);

            _uow.MarketingCampaignRepository.Update(mkt);
            _uow.Commit();

            return _mapper.Map<MarketingCampaignViewModel>(mkt);
        }
        public MarketingCampaignViewModel Delete(int id)
        {
            var mkt = this._uow.MarketingCampaignRepository.GetById(m => m.MarketingCampaignID == id);
            if (mkt == null)
            {
                return null;
            }

            _uow.MarketingCampaignRepository.Delete(mkt);
            _uow.Commit();

            return _mapper.Map<MarketingCampaignViewModel>(mkt);
        }
    }
}