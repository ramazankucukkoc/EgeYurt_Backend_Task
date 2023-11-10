# EgeYurt_Backend_Task
 ## Swagger ekledim projeme apilerdeki ekleme,silme,güncelleme ,listeleme işlemlerini tamamladım.
 ![image](https://github.com/ramazankucukkoc/EgeYurt_Backend_Task/assets/79471806/4b47087c-e6b6-4603-bd31-71ee1f5e5087)

 Öncelikle ekleme,silme,güncelleme ve listeleme işlemleri için sisteme login olup admin rolune sahip olmalıyım.
 
 ![image](https://github.com/ramazankucukkoc/EgeYurt_Backend_Task/assets/79471806/1e671c0d-d492-4220-b4cc-757093460439)
 
 Sisteme login olsam bile admin rolune sahip olmdagında aynı hatayı verecektir.

 Database tablolarım code-first (migration işlemi) yaklaşımıyla tamamlandı.
 
 ![image](https://github.com/ramazankucukkoc/EgeYurt_Backend_Task/assets/79471806/f078836a-6a8e-46d3-9b56-f97676177502)
 ![image](https://github.com/ramazankucukkoc/EgeYurt_Backend_Task/assets/79471806/f87cc99a-985b-4f71-9ac2-6e231296992a)
 
 Ben kendimi sisteme register edip admin rolu ekledim.Aşagıdaki 1.resimde Roller tablosu ve 2.resimde Roller ile User tablosu many-to-many ilişkisi oldugu için bir daha tablo oluşturdum onada UserOperationClaims dedim oradanda admin rolune sahip oldugum gözküyor.

 1.Resim : ![image](https://github.com/ramazankucukkoc/EgeYurt_Backend_Task/assets/79471806/09cb0119-6ad4-483f-b1ac-859eb26da915)
 2.Resim : ![image](https://github.com/ramazankucukkoc/EgeYurt_Backend_Task/assets/79471806/872b453b-d531-4a64-b39c-f143597e4ce1)

 Sisteme Giriş Yapıp Token Üretimi Gerçekleştirecem:
 ![image](https://github.com/ramazankucukkoc/EgeYurt_Backend_Task/assets/79471806/a8e86009-fce5-4b35-b1ea-b12824c51438)
 
 Admin Role token içerisinde yer almaktadır.
 ![image](https://github.com/ramazankucukkoc/EgeYurt_Backend_Task/assets/79471806/770ca30c-0bca-4a5e-8df4-10e5f1d21adc)

 Sonra swagger yer alan Authorize butonu tıklayıp Bearer yazıp sonra bir boşluk bırakıp token basıp sisteme giriş yapıyoruz.
 ![image](https://github.com/ramazankucukkoc/EgeYurt_Backend_Task/assets/79471806/f6c5186a-de74-414e-bf0f-b9c39730a21f)

 Ondan sonra sistemde listeleme,silme,ekleme,güncelleme yapabiliriz. :)
 ![image](https://github.com/ramazankucukkoc/EgeYurt_Backend_Task/assets/79471806/98b16b7d-0669-49d9-91b7-c75308569fe4)

 ![image](https://github.com/ramazankucukkoc/EgeYurt_Backend_Task/assets/79471806/864f86b7-c5aa-447a-b931-2d60c712c55b)

 ![image](https://github.com/ramazankucukkoc/EgeYurt_Backend_Task/assets/79471806/cc6c27f9-9d0f-405b-9ae8-8d69c0b567c4)

 ## 1.Authorization Klasörunde :AuthorizationBehavior class'ında sisteme rollerimiz ve authentication olup olmadıgımızı kontrol ettigimiz sınıf'tır.
 ## 2.DataAccess veri tabanıma erişim klasörüdür burada migrationslarımız,entitylerimiz configuration işlemleri yer alıyor ayrıca repository lerimizde burada yer alıyor.
 ## 3.Entities klasörunde ise veritabanımızdaki tablolara karşılık gelen varlıklardır.
 ## 4.Extensions claims(rollerimizi) ClaimExtensions class'da jwt token içerisine emial,adını,id,rolleri içersine basmamızı sağlayan class.Ayrıca ClaimsPrincipalExtensions ise rolleri token çekme işlemi ayrıca kullanıcının id token içerisnde alıyoruz.
 ## 5.Helpers klasörunde ise kullanıcıların şifrelerini hashleme(HMACSHA512) işlemleri yer alıyor.
 ## 6.Security klasörunde ise jwt ve refreshtoken üretimi yapılan klasör.
 ## 7.Services klasörunde add,delete,register,login,getall,update işlemleri için yazılan ayrıca kontorllerin(null Check,password verification vs.) yapıldıgı klasördür.
 
 
