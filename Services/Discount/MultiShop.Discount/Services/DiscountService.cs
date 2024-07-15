using Dapper;
using MultiShop.Discount.Context;
using MultiShop.Discount.Dtos;

namespace MultiShop.Discount.Services
{
    public class DiscountService : IDiscountService
    {
        private readonly DapperContext _context;

        public DiscountService(DapperContext context)
        {
            _context = context;
        }

        public async Task CreateDiscountCouponAsync(CreateDiscountCouponDto createDiscountCouponDto)
        {
            string query = "insert into Coupons (Code,Rate,isActive,ValidDate) values (@code,@rate,@isActive,@ValidDate)";
            
            var parameters = new DynamicParameters();
            parameters.Add("@code", createDiscountCouponDto.Code);
            parameters.Add("@rate", createDiscountCouponDto.Rate);
            parameters.Add("@isActive", createDiscountCouponDto.isActive);
            parameters.Add("@ValidDate", createDiscountCouponDto.ValidDate);
            
            using(var connection = _context.CreateConnection())
            {
                await connection.ExecuteAsync(query, parameters);
            }
        }

        public async Task DeleteDiscountCouponAsync(int id)
        {
            string query = "Delete from Coupons where CouponId=@couponId";

            var parameters = new DynamicParameters();
            parameters.Add("@couponId", id);

            using(var connections = _context.CreateConnection())
            {
                await connections.ExecuteAsync(query, parameters);
            }
        }

        public async Task<List<ResultDiscountCouponDto>> GetAllDiscountCouponAsync()
        {
            string query = "Select * from Coupons";

            using(var connection = _context.CreateConnection())
            {
                var values = await connection.QueryAsync<ResultDiscountCouponDto>(query);
                return values.ToList();
            }
        }

        public async Task<GetByIdDiscountCouponDto> GetByIdDiscountCouponAsync(int id)
        {
            string query = "Select * from Coupons where CouponId=@couponId";

            var parameters = new DynamicParameters();
            parameters.Add("@couponId", id);

            using (var connections = _context.CreateConnection())
            {
                return await connections.QueryFirstOrDefaultAsync<GetByIdDiscountCouponDto>(query, parameters);
            }
        }

        public async Task<ResultDiscountCouponDto> GetCodeDetailByCodeAsync(string code)
        {
            string query = "Select * From Coupons Where Code=@code";
            var parameters = new DynamicParameters();
            parameters.Add("@code", code);

            using (var connections = _context.CreateConnection())
            {
                return await connections.QueryFirstOrDefaultAsync<ResultDiscountCouponDto>(query, parameters);
            }
        }

        public async Task<int> GetDiscountCouponCount()
        {
            string query = "Select Count(*) From Coupons";
            using (var connections = _context.CreateConnection())
            {
                var value =  await connections.QueryFirstOrDefaultAsync<int>(query);
                return value;
            }
        }

        public int GetDiscountCouponRate(string code)
        {
            string query = "Select Rate From Coupons Where Code=@code";
            var parameters = new DynamicParameters();
            parameters.Add("@code", code);

            using (var connections = _context.CreateConnection())
            {
                var values = connections.QueryFirstOrDefault<int>(query, parameters);
                return values;
            }
        }

        public async Task UpdateDiscountCouponAsync(UpdateDiscountCouponDto updateDiscountCouponDto)
        {
            string query = "Update Coupons Set Code=@code,Rate=@rate,isActive=@isActive,ValidDate=@ValidDate where CouponId=@couponId";
            
            var parameters = new DynamicParameters();
            parameters.Add("@code", updateDiscountCouponDto.Code);
            parameters.Add("@rate", updateDiscountCouponDto.Rate);
            parameters.Add("@isActive", updateDiscountCouponDto.isActive);
            parameters.Add("@ValidDate", updateDiscountCouponDto.ValidDate);
            parameters.Add("@couponId", updateDiscountCouponDto.CouponId);

            using (var connection = _context.CreateConnection())
            {
                await connection.ExecuteAsync(query, parameters);
            }
        }
    }
}
