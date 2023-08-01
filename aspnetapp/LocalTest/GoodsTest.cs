using aspnetapp.Controllers;
using Common.Enumeraties;
using Common.Utilities;
using Models;

namespace aspnetapp.LocalTest
{
    public static class GoodsTest
    {
        public static async Task GetGoodsInfoTestAsync()
        {
            await new GoodsController().GetGoodsInfo(new GoodsSearch { pageIndex = 1, pageSize = 10 });
        }


    }
}
