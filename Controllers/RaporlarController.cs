using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using RaporFront.Data;
using RaporFront.Models;
using RaporFront.NewFolder;
using RaporFront.ViewModels;
using System.Data;

namespace RaporFront.Controllers
{
    public class RaporlarController : Controller
    {
        private readonly UygulamaDbContext _dbContext;
        private readonly string _connectionString;

        public RaporlarController(UygulamaDbContext dbContext, IConfiguration configuration)
        {
            _dbContext = dbContext;
            _connectionString = configuration.GetConnectionString("DefaultConnection");
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]



        [HttpGet]
        public JsonResult Finans_veri_cek(string BaslangicTarihi, string BitisTarihi, int? OrderID)
        {
            DateTime? baslangicTarihi = null;
            DateTime? bitisTarihi = null;

            if (!string.IsNullOrEmpty(BaslangicTarihi))
                baslangicTarihi = DateTime.Parse(BaslangicTarihi);

            if (!string.IsNullOrEmpty(BitisTarihi))
                bitisTarihi = DateTime.Parse(BitisTarihi);

            Console.WriteLine("Başlangıç: " + baslangicTarihi);
            Console.WriteLine("Bitiş: " + bitisTarihi);
            Console.WriteLine("OrderID: " + OrderID);

            var result = new List<OrderDetailDto>();

            using (SqlConnection conn = new SqlConnection(_connectionString))
            {
                using (SqlCommand cmd = new SqlCommand("dbo.Get_Order_Details", conn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    

                    cmd.Parameters.AddWithValue("@BaslangicTarihi", (object)baslangicTarihi ?? DBNull.Value);
                    cmd.Parameters.AddWithValue("@BitisTarihi", (object)bitisTarihi ?? DBNull.Value);
                    cmd.Parameters.AddWithValue("@OrderID", (object)OrderID ?? DBNull.Value);

                    //cmd.Parameters.AddWithValue("@OrderID", OrderID);

                    conn.Open();

                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            var detail = new OrderDetailDto
                            {
                                OrderID = Convert.ToInt32(reader["OrderID"]),
                                CustomerID = reader["CustomerID"].ToString(),
                                EmployeeID = Convert.ToInt32(reader["EmployeeID"]),
                                OrderDate = Convert.ToDateTime(reader["OrderDate"]),
                                EmployeeLastName = reader["EmployeeLastName"].ToString(),
                                EmployeeFirstName = reader["EmployeeFirstName"].ToString(),
                                EmployeeTitle = reader["EmployeeTitle"].ToString(),
                                CompanyName = reader["CompanyName"].ToString(),
                                ContactName = reader["ContactName"].ToString(),
                                ContactTitle = reader["ContactTitle"].ToString(),
                                Phone = reader["Phone"].ToString(),
                                ProductID = Convert.ToInt32(reader["ProductID"]),
                                ProductName = reader["ProductName"].ToString(),
                                UnitPrice = Convert.ToDecimal(reader["UnitPrice"]),
                                UnitsInStock = Convert.ToInt16(reader["UnitsInStock"])
                            };

                            result.Add(detail);
                        }
                    }
                }
            }

            return new JsonResult(result);
        }

        public JsonResult Lojistik_veri_cek(string BaslangicTarihi, string BitisTarihi)
        {
            DateTime? baslangicTarihi = null;
            DateTime? bitisTarihi = null;

            if (!string.IsNullOrEmpty(BaslangicTarihi))
                baslangicTarihi = DateTime.Parse(BaslangicTarihi);

            if (!string.IsNullOrEmpty(BitisTarihi))
                bitisTarihi = DateTime.Parse(BitisTarihi);

            var result = new List<LojistikDto>();

            using (SqlConnection conn = new SqlConnection(_connectionString))
            {
                using (SqlCommand cmd = new SqlCommand("dbo.Get_Lojistik_Details", conn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue("@BaslangicTarihi", (object)baslangicTarihi ?? DBNull.Value);
                    cmd.Parameters.AddWithValue("@BitisTarihi", (object)bitisTarihi ?? DBNull.Value);

                    conn.Open();

                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            var detail = new LojistikDto
                            {
                                OrderID = Convert.ToInt32(reader["OrderID"]),
                                ShipName = reader["ShipName"].ToString(),
                                ShipAddress = reader["ShipAddress"].ToString(),
                                ShipCity = reader["ShipCity"].ToString(),
                                ShipCountry = reader["ShipCountry"].ToString(),
                                ShipperName = reader["ShipperName"].ToString()
                            };

                            result.Add(detail);
                        }
                    }
                }
            }

            return new JsonResult(result);
        }
        [HttpGet]
        [Route("Raporlar/Uretim_veri_cek")]

        public JsonResult Uretim_veri_cek()
        {
            var result = new List<UretimDto>();

            using (SqlConnection conn = new SqlConnection(_connectionString))
            {
                using (SqlCommand cmd = new SqlCommand("dbo.Get_Uretim_Details", conn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;

                    conn.Open();

                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            var detail = new UretimDto
                            {
                                ProductID = Convert.ToInt32(reader["ProductID"]),
                                ProductName = reader["ProductName"].ToString(),
                                CategoryName = reader["CategoryName"].ToString(),
                                UnitsInStock = Convert.ToInt16(reader["UnitsInStock"])
                            };

                            result.Add(detail);
                        }
                    }
                }
            }

            return new JsonResult(result);
        }

        [HttpGet]
        [Route("Raporlar/Cari_veri_cek")]
        public JsonResult Cari_veri_cek()
        {
            var result = new List<CariDto>();

            using (SqlConnection conn = new SqlConnection(_connectionString))
            {
                using (SqlCommand cmd = new SqlCommand("dbo.Get_Cari_Details", conn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;

                    conn.Open();

                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            var dto = new CariDto
                            {
                                CustomerID = reader["CustomerID"].ToString(),
                                CompanyName = reader["CompanyName"].ToString(),
                                ContactName = reader["ContactName"].ToString(),
                                Phone = reader["Phone"].ToString()
                            };

                            result.Add(dto);
                        }
                    }
                }
            }

            return new JsonResult(result);
        }


        [HttpGet]
        public IActionResult Finans_Grafik_veri_cek(DateTime? BaslangicTarihi, DateTime? BitisTarihi)
        {
            var result = new List<dynamic>();

            using (SqlConnection conn = new SqlConnection(_connectionString))
            {
                using (SqlCommand cmd = new SqlCommand("dbo.Get_Order_Details_Summary", conn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@BaslangicTarihi", (object)BaslangicTarihi ?? DBNull.Value);
                    cmd.Parameters.AddWithValue("@BitisTarihi", (object)BitisTarihi ?? DBNull.Value);

                    conn.Open();
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            result.Add(new
                            {
                                OrderDate = reader["OrderDate"]?.ToString(),
                                TotalUnitPrice = reader["TotalUnitPrice"] != DBNull.Value
                                                 ? Convert.ToDecimal(reader["TotalUnitPrice"])
                                                 : 0
                            });
                        }
                    }
                }
            }

            return Json(result);
        }

        
        [HttpPost]
        public IActionResult TaslakKaydet([FromBody] TaslakKaydetDto dto)
        {
            var taslak = new RaporTaslak()
            {
                KullaniciID = dto.KullaniciID,
                RaporAdi = dto.RaporAdi,
                TaslakAdi = dto.TaslakAdi,
                Sutunlar = JsonConvert.SerializeObject(dto.SecilenSutunlar),
                KayitTarihi = DateTime.Now,
                BaslangicTarihi = dto.BaslangicTarihi,
                BitisTarihi = dto.BitisTarihi
            };

            _dbContext.RaporTaslaklari.Add(taslak);
            _dbContext.SaveChanges();

            return Ok(new { success = true });
        } 

        



        [HttpGet]
        public IActionResult TaslaklariGetir(string raporAdi)
        {
            
            var liste = _dbContext.RaporTaslaklari
                .Where(x => x.RaporAdi == raporAdi)
                .Select(x => new
                {
                    x.TaslakID,
                    x.TaslakAdi
                }).ToList();

            return Ok(liste);
        }

        [HttpGet]
        public IActionResult TaslakDetay(int taslakID)
        {
            var taslak = _dbContext.RaporTaslaklari.Find(taslakID);
            if (taslak == null) return NotFound();

            var sutunlar = JsonConvert.DeserializeObject<List<string>>(taslak.Sutunlar);

            return Ok(new
            {
                Sutunlar = sutunlar,
                BaslangicTarihi = taslak.BaslangicTarihi?.ToString("yyyy-MM-dd"),
                BitisTarihi = taslak.BitisTarihi?.ToString("yyyy-MM-dd")
            });
        }


        [HttpPost]
        public IActionResult TaslakSil(int taslakID)
        {
            var taslak = _dbContext.RaporTaslaklari.Find(taslakID);
            if (taslak == null)
                return NotFound();

            _dbContext.RaporTaslaklari.Remove(taslak);
            _dbContext.SaveChanges();

            return Ok(new { success = true });
        }

        [HttpGet]
        public JsonResult TumTaslaklariGetir()
        {
            var taslaklar = _dbContext.RaporTaslaklari
                .Select(x => new { x.TaslakID, x.TaslakAdi, x.RaporAdi })
                .ToList();

            return Json(taslaklar);
        }

        [HttpGet]
        public JsonResult KpiVerileriGetir()
        {
            var result = new KPIDto();

            using (var connection = new SqlConnection(_connectionString))
            {
                connection.Open();
                using (var command = new SqlCommand("GetKPIValues", connection))
                {
                    command.CommandType = CommandType.StoredProcedure;

                    using (var reader = command.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            result.Musteri = Convert.ToInt32(reader["KPI_Musteri"]);
                        }

                        if (reader.NextResult() && reader.Read())
                        {
                            result.Stok = Convert.ToInt32(reader["KPI_Stok"]);
                        }

                        if (reader.NextResult() && reader.Read())
                        {
                            result.Ulke = reader["KPI_Ulke"].ToString();
                        }
                    }
                }
            }

            return Json(result);
        }

        [HttpGet]
        public JsonResult UlkelereGoreSiparisGetir()
        {
            List<CountryOrderDto> liste = new();

            using (var connection = new SqlConnection(_connectionString))
            {
                connection.Open();
                using (var command = new SqlCommand("GetOrdersByCountry", connection))
                {
                    command.CommandType = CommandType.StoredProcedure;

                    using (var reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            liste.Add(new CountryOrderDto
                            {
                                Ulke = reader["Ulke"].ToString(),
                                SiparisSayisi = Convert.ToInt32(reader["SiparisSayisi"])
                            });
                        }
                    }
                }
            }

            return Json(liste);
        }

        [HttpGet]
        public JsonResult AylaraGoreSiparisGetir()
        {
            var liste = new List<object>();

            using (SqlConnection con = new SqlConnection(_connectionString))
            {
                using (SqlCommand cmd = new SqlCommand("SiparisleriAylaraGoreGetir", con))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    con.Open();
                    using (SqlDataReader rdr = cmd.ExecuteReader())
                    {
                        while (rdr.Read())
                        {
                            liste.Add(new
                            {
                                ay = rdr["Ay"].ToString(),
                                siparisSayisi = Convert.ToInt32(rdr["SiparisSayisi"])
                            });
                        }
                    }
                }
            }

            return Json(liste);
        }




    }
}
