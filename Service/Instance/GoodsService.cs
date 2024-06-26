﻿using AutoMapper;
using Common.Utilities;
using DataBase;
using DataBase.Entitys;
using Microsoft.EntityFrameworkCore;
using Models;
using Service.Interface;

namespace Service.Instance
{
    public class GoodsService: IGoodsService
    {
        private readonly GoodsContext _context;
        private readonly IMapper _mapper;

        public GoodsService(GoodsContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }


        public void Increase(GoodsDto dto)
        {
            dto.creationTime = DateTime.Now;
            var entity = _mapper.Map<Goods>(dto);
            _context.Goods.Add(entity);
            var unused = _context.SaveChanges();
        }

        public async Task<(List<GoodsDto>, int)> Search(GoodsSearch search)
        {
            var query = _context.Goods.AsNoTracking().Where(n => !n.cancelTime.HasValue);
            (int total, int pageIndex, int pageSize, string sortBy, string direction) = search.GetDefaultCondition();

            if (!string.IsNullOrWhiteSpace(search.tag))
            {
                query = query.Where(n => n.tag != null && n.tag.Contains(search.tag));
            }
            if (search.lstStoreId?.Count > 0)
            {
                query = query.Where(n => n.storeId.HasValue && search.lstStoreId.Contains(n.storeId.Value));
            }
            if (!string.IsNullOrWhiteSpace(search.title))
            {
                query = query.Where(n => n.title != null && n.title.Contains(search.title));
            }
            if (search.available.HasValue)
            {
                query = query.Where(n => n.available == search.available);
            }
            if (search.isPutOnSale.HasValue)
            {
                query = query.Where(n => n.isPutOnSale == search.isPutOnSale);
            }

            total = query.Count();

            // .SortBy($"{sortBy} {direction}");
            query = query.OrderByDescending(n=>n.soldNum).ThenByDescending(n=>n.hitQuantity).ThenByDescending(n=>n.stockQuantity).Skip((pageIndex - 1) * pageSize).Take(pageSize);
            return (_mapper.Map<List<GoodsDto>>(await query.ToListAsync()), total);
        }


        public async Task<(List<GoodsDto>, int)> SearchResult(GoodsSearch search)
        {
            var query = _context.Goods.AsNoTracking().Where(n => !n.cancelTime.HasValue);
            (int total, int pageIndex, int pageSize, string sortBy, string direction) = search.GetDefaultCondition();

            if (!string.IsNullOrWhiteSpace(search.title))
            {
                query = query.Where(n => (n.title != null && n.title.Contains(search.title)) || (n.etitle != null && n.etitle.Contains(search.title)));
            }
            if (search.available.HasValue)
            {
                query = query.Where(n => n.available == search.available);
            }
            if (search.isPutOnSale.HasValue)
            {
                query = query.Where(n => n.isPutOnSale == search.isPutOnSale);
            }
            if (search.minSalePrice.HasValue)
            {
                query = query.Where(n => n.minSalePrice >= search.minSalePrice);
            }
            if (search.maxSalePrice.HasValue)
            {
                query = query.Where(n => n.minSalePrice <= search.maxSalePrice);
            }

            total = query.Count();

            query = query.Sort(sortBy, direction).Skip((pageIndex - 1) * pageSize).Take(pageSize);
            return (_mapper.Map<List<GoodsDto>>(await query.ToListAsync()), total);
        }
    }
}