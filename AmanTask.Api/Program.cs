

using AmanTask.Api.Helper;
using AmanTask.Core.Repository;
using AmanTask.EF.Repositories;

var builder = WebApplication.CreateBuilder(args);

//add cors 
string text = "";

//add db context
var connection = builder.Configuration.GetConnectionString("DefultConnection");
builder.Services.AddDbContext<ApplicationDBContext>(
    op=>op.UseSqlServer(connection));

// add services
builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();
//services.AddTransient(typeof(IBaseRepository<>), typeof(BaseRepository<>));

//add auto maper service
builder.Services.AddAutoMapper(typeof(MappingProfile));

//add cors
builder.Services.AddCors(options =>
{
    options.AddPolicy(text,
    builder =>
    {
        builder.AllowAnyOrigin();
        //builder.WithOrigins("url");
        builder.AllowAnyMethod();
        builder.AllowAnyHeader();
    });
});


builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();
app.UseCors(text);

app.MapControllers();

app.Run();
