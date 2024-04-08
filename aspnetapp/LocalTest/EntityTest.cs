using Common.Enumeraties;
using Common.Utilities;
using DataBase;
using EntityDataBase;
using EntityService;
using MindrayApp.Model.RD;
using Models;
using System.Data.Entity;
using System.Data.Entity.Validation;

namespace aspnetapp.LocalTest
{
    public static class EntityTest
    {
        public static void SearchMediasTest()
        {
            var search = new MediasSearch { tableType = (short)TableTypeEnum.None, mType = (short)MediaTypeEnum.Image, tableId = (long)PageEnum.Home };
            try
            {
                var context = new MediasContext();
                var query = context.Medias;
                //var context = new CategorysContext();
                //var query = context.Categorys.AsNoTracking();

                //if (search.tableType.HasValue)
                //{
                //    query = query.Where(n => n.tableType == search.tableType);
                //}
                //if (search.mType.HasValue)
                //{
                //    query = query.Where(n => n.mType == search.mType);
                //}
                //if (search.tableId.HasValue)
                //{
                //    query = query.Where(n => n.tableId == search.tableId);
                //}
                //if (search.tableIds?.Count > 0)
                //{
                //    query = query.Where(n => n.tableId.HasValue && search.tableIds.Contains(n.tableId.Value));
                //}
                //if (!string.IsNullOrWhiteSpace(search.flag))
                //{
                //    query = query.Where(n => n.flag == search.flag);
                //}
                var lst = query.ToList();
            }
            catch (DbEntityValidationException e)
            {
                var msg = e.EntityValidationErrors.ToArray()[0].ValidationErrors.ToArray()[0].ErrorMessage;
            }
            catch (Exception ex)
            {

            }
        }

        public static void GetPopularsTest()
        {
            SearchBase search = new MediasSearch { pageSize = 16 };
            try
            {
                var context = new KeywordHistorysContext();
                (int total, int pageIndex, int pageSize, string sortBy, string direction) = search.GetDefaultCondition();
#pragma warning disable CS8602 // 解引用可能出现空引用。
                var query = context.KeywordHistorys
                    .GroupBy(m => new { m.content })
                    .Select(n => new KeywordHistorysSummary
                    {
                        content = n.Key.content,
                        number = n.Count(),
                        creationTime = n.Where(k => k.creationTime.HasValue).OrderBy(k => k.creationTime).FirstOrDefault().creationTime
                    });
#pragma warning restore CS8602 // 解引用可能出现空引用。

                var result = query.OrderByDescending(n => n.number).ThenBy(n => n.creationTime).Skip((pageIndex - 1) * pageSize).Take(pageSize).Select(n => n.content).ToList();

            }
            catch (DbEntityValidationException e)
            {
                var msg = e.EntityValidationErrors.ToArray()[0].ValidationErrors.ToArray()[0].ErrorMessage;
            }
            catch (Exception ex)
            {

            }
        }

        public static void SearchResultText()
        {
            var search = new GoodsSearch { available = true, isPutOnSale = true, sortBy = "minSalePrice", direction = "ASC" };
            var context = new GoodsContext();
            var query = context.Goods.Where(n => !n.cancelTime.HasValue);
            (int total, int pageIndex, int pageSize, string sortBy, string direction) = search.GetDefaultCondition();

            if (!string.IsNullOrWhiteSpace(search.title))
            {
                query = query.Where(n => n.title != null && n.title.Contains(search.title) || n.etitle != null && n.etitle.Contains(search.title));
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
            var lst = query.ToList();
        }

        public static void LinqDynamicQueryTest()
        {
            var lstParamsDto = new EntityLstParamsDto
            {
                ParamOperator = OperatorEnum.And,
                LstEntityParams = new List<EntityParamsDto>
                {
                    new EntityParamsDto
                    {
                          LstEntityParam = new List<EntityParamDto>
                          {
                              new EntityParamDto
                              {
                                  ParamOperator = OperatorEnum.Contants,
                                  FieldName = "FReqDesc",
                                  FieldValue = @"""a""",
                              },
                              new EntityParamDto
                              {
                                  ParamOperator = OperatorEnum.Contants,
                                  FieldName = "FSolution",
                                  FieldValue = @"""a""",
                              },
                              new EntityParamDto
                              {
                                  ParamOperator = OperatorEnum.Contants,
                                  FieldName = "FUserReqSource",
                                  FieldValue = @"""a""",
                              },
                              new EntityParamDto
                              {
                                  ParamOperator = OperatorEnum.Contants,
                                  FieldName = "FUserReqDesc",
                                  FieldValue = @"""a""",
                              },
                              new EntityParamDto
                              {
                                  ParamOperator = OperatorEnum.Contants,
                                  FieldName = "FKeyWord",
                                  FieldValue = @"""a""",
                              },
                              new EntityParamDto
                              {
                                  ParamOperator = OperatorEnum.Contants,
                                  FieldName = "FCompetition",
                                  FieldValue = @"""a""",
                              },
                              new EntityParamDto
                              {
                                  ParamOperator = OperatorEnum.Contants,
                                  FieldName = "FAcceptance",
                                  FieldValue = @"""a""",
                              },
                          }
                    },
                    new EntityParamsDto
                    {
                          LstEntityParam = new List<EntityParamDto>
                          {
                              new EntityParamDto
                              {
                                  ParamOperator = OperatorEnum.Contants,
                                  FieldName = "FSubject",
                                  FieldValue = @"""单""",
                              },
                          }
                    },
                    new EntityParamsDto
                    {
                          LstEntityParam = new List<EntityParamDto>
                          {
                              new EntityParamDto
                              {
                                  ParamOperator = OperatorEnum.Contants,
                                  FieldName = "FNo",
                                  FieldValue = @"""0001""",
                              },
                          }
                    }
                }
            };

            var lst = new Base().Query<vw_REQ_ApplyExp, RDDataBase>(lstParamsDto);
        }

        public static void LinqDynamicUpdateTest()
        {
            var result = new Base().Update<TB_REQ_Apply, RDDataBase>("FID==07DF033F-A12E-4646-A746-06FEF2BECF5D".MapDynStr(), new Dictionary<string, object> { ["FSubject"] = "东路", ["FUserReqSource"] = "网络" });
            //var result = new Base().Update<TB_REQ_Apply, RDDataBase>("FID==07DF033F-A12E-4646-A746-06FEF2BECF5D".MapDynStr(), @"new(""你好啊"" as FSubject,""哈哈哈嘿嘿"" as FUserReqSource)");
        }

        public static void LinqDynamicRemoveTest()
        {
            var result = new Base().Remove<TB_REQ_ReqLatitudeOptions, RDDataBase>("FID==47666781-CADC-4FA8-B21E-445557FC8D0C".MapDynStr());
        }
    }
}
