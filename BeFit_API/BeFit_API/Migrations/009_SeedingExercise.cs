using FluentMigrator;

namespace BeFit_API.Migrations
{
    [Migration(9)]
    public class _009_SeedingExercise : Migration
    {
        public override void Down()
        {
            
        }
        public override void Up()
        {
            Insert.IntoTable(tableName: "Exercise").Row(new
            {
                Id = Guid.Parse("9b674714-2d94-4c65-bc2d-19213bcf4f30")
                ,
                BodyPart = "chest"
                ,
                Equipment = "dumbbell"
                ,
                GifUrl = "https://res.cloudinary.com/dxx6cjnjj/image/upload/v1685980157/0314_lqutb9.gif"
                ,
                Name = "dumbbell incline bench press"
                ,
                SetsPlan = "4 sets 8-12 reps"
                ,
                Target = "pectorals"
                ,
                Plan = "Upper Body"
                ,
                IsActive = true
            });
            Insert.IntoTable(tableName: "Exercise").Row(new
            {
                Id = Guid.Parse("7575a26f-99f2-458d-b049-b41c464dd393")
                ,
                BodyPart = "chest"
                ,
                Equipment = "barbell"
                ,
                GifUrl = "https://res.cloudinary.com/dxx6cjnjj/image/upload/v1685980739/0025_finwsl.gif"
                ,
                Name = "barbell bench press"
                ,
                SetsPlan = "4 sets 8-12 reps"
                ,
                Target = "pectorals"
                ,
                Plan = "Upper Body"
                ,
                IsActive = true
            });
            Insert.IntoTable(tableName: "Exercise").Row(new
            {
                Id = Guid.Parse("4b19c9f4-cadc-4467-94d6-d1e5d2db61fb")
                ,
                BodyPart = "shoulders"
                ,
                Equipment = "dumbbell"
                ,
                GifUrl = "https://res.cloudinary.com/dxx6cjnjj/image/upload/v1685980809/0383_k11egw.gif"
                ,
                Name = "dumbbell reverse fly"
                ,
                SetsPlan = "4 sets 8-12 reps"
                ,
                Target = "delts"
                ,
                Plan = "Upper Body"
                ,
                IsActive = true
            });
            Insert.IntoTable(tableName: "Exercise").Row(new
            {
                Id = Guid.Parse("581b2432-c1cd-4027-ab1b-d12d2a2ee8f7")
                ,
                BodyPart = "back"
                ,
                Equipment = "cable"
                ,
                GifUrl = "https://res.cloudinary.com/dxx6cjnjj/image/upload/v1685980846/0150_dpfo7j.gif"
                ,
                Name = "cable bar lateral pulldown"
                ,
                SetsPlan = "4 sets 8-12 reps"
                ,
                Target = "lats"
                ,
                Plan = "Upper Body"
                ,
                IsActive = true
            });
            Insert.IntoTable(tableName: "Exercise").Row(new
            {
                Id = Guid.Parse("649a0145-9c5f-4e7e-8bf6-af88b3ed9908")
                ,
                BodyPart = "upper arms"
                ,
                Equipment = "dumbbell"
                ,
                GifUrl = "https://res.cloudinary.com/dxx6cjnjj/image/upload/v1685980894/0294_sscjgz.gif"
                ,
                Name = "dumbbell biceps curl"
                ,
                SetsPlan = "3 sets 12-15 reps"
                ,
                Target = "biceps"
                ,
                Plan = "Upper Body"
                ,
                IsActive = true
            });
            Insert.IntoTable(tableName: "Exercise").Row(new
            {
                Id = Guid.Parse("d24f9872-4e8f-4aa2-b814-c8cbe2af811a")
                ,
                BodyPart = "shoulders"
                ,
                Equipment = "dumbbell"
                ,
                GifUrl = "https://res.cloudinary.com/dxx6cjnjj/image/upload/v1685980944/0334_q1scij.gif"
                ,
                Name = "dumbbell lateral raise"
                ,
                SetsPlan = "3 sets 12-15 reps"
                ,
                Target = "delts"
                ,
                Plan = "Upper Body"
                ,
                IsActive = true
            });
            Insert.IntoTable(tableName: "Exercise").Row(new
            {
                Id = Guid.Parse("75f855bb-0aff-4d4d-9adf-e6e0b18562b7")
                ,
                BodyPart = "upper legs"
                ,
                Equipment = "barbell"
                ,
                GifUrl = "https://res.cloudinary.com/dxx6cjnjj/image/upload/v1685980980/0043_xbxxun.gif"
                ,
                Name = "barbell full squat"
                ,
                SetsPlan = "4 sets 8-12 reps"
                ,
                Target = "glutes"
                ,
                Plan = "Lower Body"
                ,
                IsActive = true
            });
            Insert.IntoTable(tableName: "Exercise").Row(new
            {
                Id = Guid.Parse("6e74e389-783c-4f7d-b600-7f9bb875a71f")
                ,
                BodyPart = "upper legs"
                ,
                Equipment = "dumbbell"
                ,
                GifUrl = "https://res.cloudinary.com/dxx6cjnjj/image/upload/v1685981053/0381_kcwons.gif"
                ,
                Name = "dumbbell rear lunge"
                ,
                SetsPlan = "4 sets 8-12 reps"
                ,
                Target = "glutes"
                ,
                Plan = "Lower Body"
                ,
                IsActive = true
            });
            Insert.IntoTable(tableName: "Exercise").Row(new
            {
                Id = Guid.Parse("f5d7b139-9efe-4e20-92b7-2ebf9fdb67ec")
                ,
                BodyPart = "upper legs"
                ,
                Equipment = "leverage machine"
                ,
                GifUrl = "https://res.cloudinary.com/dxx6cjnjj/image/upload/v1685981263/0585_gid5b1.gif"
                ,
                Name = "lever leg extension"
                ,
                SetsPlan = "4 sets 8-12 reps"
                ,
                Target = "quads"
                ,
                Plan = "Lower Body"
                ,
                IsActive = true
            });
            Insert.IntoTable(tableName: "Exercise").Row(new
            {
                Id = Guid.Parse("9761fff8-8877-46ba-a65a-beea3bdf9381")
                ,
                BodyPart = "upper legs"
                ,
                Equipment = "leverage machine"
                ,
                GifUrl = "https://res.cloudinary.com/dxx6cjnjj/image/upload/v1685981263/0585_gid5b1.gif"
                ,
                Name = "lever lying leg curl"
                ,
                SetsPlan = "3 sets 12-15 reps"
                ,
                Target = "hamstrings"
                ,
                Plan = "Lower Body"
                ,
                IsActive = true
            });
            Insert.IntoTable(tableName: "Exercise").Row(new
            {
                Id = Guid.Parse("6c6d6f81-eb16-42aa-84ed-f38ff0827aae")
                ,
                BodyPart = "lower legs"
                ,
                Equipment = "body weight"
                ,
                GifUrl = "https://res.cloudinary.com/dxx6cjnjj/image/upload/v1685981364/1373_lcwmcc.gif"
                ,
                Name = "bodyweight standing calf raise"
                ,
                SetsPlan = "3 sets 12-15 reps"
                ,
                Target = "calves"
                ,
                Plan = "Lower Body"
                ,
                IsActive = true
            });
            Insert.IntoTable(tableName: "Exercise").Row(new
            {
                Id = Guid.Parse("3da535de-5cfd-4a21-9255-60779c7dc127")
                ,
                BodyPart = "chest"
                ,
                Equipment = "dumbbell"
                ,
                GifUrl = "https://res.cloudinary.com/dxx6cjnjj/image/upload/v1685980157/0314_lqutb9.gif"
                ,
                Name = "dumbbell incline bench press"
                ,
                SetsPlan = "4 sets 8-12 reps"
                ,
                Target = "pectorals"
                ,
                Plan = "Push Day"
                ,
                IsActive = true
            });
            Insert.IntoTable(tableName: "Exercise").Row(new
            {
                Id = Guid.Parse("500f859b-d9e4-4152-9090-1e5602170e80")
                ,
                BodyPart = "shoulders"
                ,
                Equipment = "barbell"
                ,
                GifUrl = "https://res.cloudinary.com/dxx6cjnjj/image/upload/v1685981434/1456_gy3ago.gif"
                ,
                Name = "barbell standing close grip military press"
                ,
                SetsPlan = "4 sets 8-12 reps"
                ,
                Target = "delts"
                ,
                Plan = "Push Day"
                ,
                IsActive = true
            });
            Insert.IntoTable(tableName: "Exercise").Row(new
            {
                Id = Guid.Parse("cfb5fc5a-84a9-438d-9359-598271a2e9ec")
                ,
                BodyPart = "shoulders"
                ,
                Equipment = "dumbbell"
                ,
                GifUrl = "https://res.cloudinary.com/dxx6cjnjj/image/upload/v1685980944/0334_q1scij.gif"
                ,
                Name = "dumbbell lateral raise"
                ,
                SetsPlan = "4 sets 8-12 reps"
                ,
                Target = "delts"
                ,
                Plan = "Push Day"
                ,
                IsActive = true
            });
            Insert.IntoTable(tableName: "Exercise").Row(new
            {
                Id = Guid.Parse("c194752f-23bd-405f-8ee1-66dad6ed732d")
                ,
                BodyPart = "chest"
                ,
                Equipment = "leverage machine"
                ,
                GifUrl = "https://res.cloudinary.com/dxx6cjnjj/image/upload/v1685981514/0596_s0ehiw.gif"
                ,
                Name = "lever seated fly"
                ,
                SetsPlan = "4 sets 8-12 reps"
                ,
                Target = "pectorals"
                ,
                Plan = "Push Day"
                ,
                IsActive = true
            });
            Insert.IntoTable(tableName: "Exercise").Row(new
            {
                Id = Guid.Parse("39e1fac4-1fab-474c-bcce-863953f351aa")
                ,
                BodyPart = "upper arms"
                ,
                Equipment = "cable"
                ,
                GifUrl = "https://res.cloudinary.com/dxx6cjnjj/image/upload/v1685981561/0149_blmulx.gif"
                ,
                Name = "cable alternate triceps extension"
                ,
                SetsPlan = "3 sets 12-15 reps"
                ,
                Target = "triceps"
                ,
                Plan = "Push Day"
                ,
                IsActive = true
            });
            Insert.IntoTable(tableName: "Exercise").Row(new
            {
                Id = Guid.Parse("478c228c-b7d2-4786-a7b5-6eaedfbdfc0b")
                ,
                BodyPart = "upper arms"
                ,
                Equipment = "cable"
                ,
                GifUrl = "https://res.cloudinary.com/dxx6cjnjj/image/upload/v1685981604/0194_kcrzto.gif"
                ,
                Name = "cable overhead triceps extension (rope attachment)"
                ,
                SetsPlan = "3 sets 12-15 reps"
                ,
                Target = "triceps"
                ,
                Plan = "Push Day"
                ,
                IsActive = true
            });
            Insert.IntoTable(tableName: "Exercise").Row(new
            {
                Id = Guid.Parse("8e635d0d-7600-4ace-9d49-dfedb1d8bea8")
                ,
                BodyPart = "back"
                ,
                Equipment = "cable"
                ,
                GifUrl = "https://res.cloudinary.com/dxx6cjnjj/image/upload/v1685980846/0150_dpfo7j.gif"
                ,
                Name = "cable bar lateral pulldown"
                ,
                SetsPlan = "4 sets 8-12 reps"
                ,
                Target = "lats"
                ,
                Plan = "Pull Day"
                ,
                IsActive = true
            });
            Insert.IntoTable(tableName: "Exercise").Row(new
            {
                Id = Guid.Parse("98a9e814-2bd0-4177-a9a6-062d5fd4d489")
                ,
                BodyPart = "back"
                ,
                Equipment = "barbell"
                ,
                GifUrl = "https://res.cloudinary.com/dxx6cjnjj/image/upload/v1685981675/0027_dlbqir.gif"
                ,
                Name = "barbell bent over row"
                ,
                SetsPlan = "4 sets 8-12 reps"
                ,
                Target = "upper back"
                ,
                Plan = "Pull Day"
                ,
                IsActive = true
            });
            Insert.IntoTable(tableName: "Exercise").Row(new
            {
                Id = Guid.Parse("0414eb50-aecf-4dd4-954a-2328d6036350")
                ,
                BodyPart = "back"
                ,
                Equipment = "cable"
                ,
                GifUrl = "https://res.cloudinary.com/dxx6cjnjj/image/upload/v1685981716/1320_c71gta.gif"
                ,
                Name = "cable rope crossover seated row"
                ,
                SetsPlan = "4 sets 8-12 reps"
                ,
                Target = "upper back"
                ,
                Plan = "Pull Day"
                ,
                IsActive = true
            });
            Insert.IntoTable(tableName: "Exercise").Row(new
            {
                Id = Guid.Parse("15aaf51e-1ba4-46fb-b2fa-e9fe677a20a4")
                ,
                BodyPart = "shoulders"
                ,
                Equipment = "leverage machine"
                ,
                GifUrl = "https://res.cloudinary.com/dxx6cjnjj/image/upload/v1685981752/0602_r2stjh.gif"
                ,
                Name = "lever seated reverse fly"
                ,
                SetsPlan = "4 sets 8-12 reps"
                ,
                Target = "delts"
                ,
                Plan = "Pull Day"
                ,
                IsActive = true
            });
            Insert.IntoTable(tableName: "Exercise").Row(new
            {
                Id = Guid.Parse("5ec12bc7-12f7-4c8a-b544-861421a57927")
                ,
                BodyPart = "upper arms"
                ,
                Equipment = "dumbbell"
                ,
                GifUrl = "https://res.cloudinary.com/dxx6cjnjj/image/upload/v1685982384/0294_gz3wpg.gif"
                ,
                Name = "dumbbell biceps curl"
                ,
                SetsPlan = "3 sets 12-15 reps"
                ,
                Target = "biceps"
                ,
                Plan = "Pull Day"
                ,
                IsActive = true
            });
            Insert.IntoTable(tableName: "Exercise").Row(new
            {
                Id = Guid.Parse("1c7cb717-9261-400b-aaaa-3d74af274e32")
                ,
                BodyPart = "upper arms"
                ,
                Equipment = "dumbbell"
                ,
                GifUrl = "https://res.cloudinary.com/dxx6cjnjj/image/upload/v1685982449/0298_ei3nnp.gif"
                ,
                Name = "dumbbell cross body hammer curl"
                ,
                SetsPlan = "3 sets 12-15 reps"
                ,
                Target = "biceps"
                ,
                Plan = "Pull Day"
                ,
                IsActive = true
            });
            Insert.IntoTable(tableName: "Exercise").Row(new
            {
                Id = Guid.Parse("41c9dec5-29f1-4133-8991-159011de4092")
                ,
                BodyPart = "upper legs"
                ,
                Equipment = "barbell"
                ,
                GifUrl = "https://res.cloudinary.com/dxx6cjnjj/image/upload/v1685980980/0043_xbxxun.gif"
                ,
                Name = "barbell full squat"
                ,
                SetsPlan = "4 sets 8-12 reps"
                ,
                Target = "glutes"
                ,
                Plan = "Leg Day"
                ,
                IsActive = true
            });
            Insert.IntoTable(tableName: "Exercise").Row(new
            {
                Id = Guid.Parse("2b261376-6dab-4e66-8700-0098166c8de3")
                ,
                BodyPart = "upper legs"
                ,
                Equipment = "dumbbell"
                ,
                GifUrl = "https://res.cloudinary.com/dxx6cjnjj/image/upload/v1685981053/0381_kcwons.gif"
                ,
                Name = "dumbbell rear lunge"
                ,
                SetsPlan = "4 sets 8-12 reps"
                ,
                Target = "glutes"
                ,
                Plan = "Leg Day"
                ,
                IsActive = true
            });
            Insert.IntoTable(tableName: "Exercise").Row(new
            {
                Id = Guid.Parse("432bf61e-40b8-414b-96aa-18ed9dd32899")
                ,
                BodyPart = "upper legs"
                ,
                Equipment = "leverage machine"
                ,
                GifUrl = "https://res.cloudinary.com/dxx6cjnjj/image/upload/v1685981263/0585_gid5b1.gif"
                ,
                Name = "lever leg extension"
                ,
                SetsPlan = "4 sets 8-12 reps"
                ,
                Target = "quads"
                ,
                Plan = "Leg Day"
                ,
                IsActive = true
            });
            Insert.IntoTable(tableName: "Exercise").Row(new
            {
                Id = Guid.Parse("875f1014-0f8d-4260-a138-880f9cfb3b29")
                ,
                BodyPart = "upper legs"
                ,
                Equipment = "leverage machine"
                ,
                GifUrl = "https://res.cloudinary.com/dxx6cjnjj/image/upload/v1685981310/0586_noertv.gif"
                ,
                Name = "lever lying leg curl"
                ,
                SetsPlan = "4 sets 8-12 reps"
                ,
                Target = "hamstrings"
                ,
                Plan = "Leg Day"
                ,
                IsActive = true
            });
            Insert.IntoTable(tableName: "Exercise").Row(new
            {
                Id = Guid.Parse("2d0f0385-2bb0-40ea-8d6e-b64b6b4baaec")
                ,
                BodyPart = "lower legs"
                ,
                Equipment = "body weight"
                ,
                GifUrl = "https://res.cloudinary.com/dxx6cjnjj/image/upload/v1685981364/1373_lcwmcc.gif"
                ,
                Name = "bodyweight standing calf raise"
                ,
                SetsPlan = "4 sets 8-12 reps"
                ,
                Target = "calves"
                ,
                Plan = "Leg Day"
                ,
                IsActive = true
            });
            Insert.IntoTable(tableName: "Exercise").Row(new
            {
                Id = Guid.Parse("dd35a0be-618e-46e1-a23f-311dee28e2de")
                ,
                BodyPart = "upper legs"
                ,
                Equipment = "sled machine"
                ,
                GifUrl = "https://res.cloudinary.com/dxx6cjnjj/image/upload/v1685982692/0739_ctgjar.gif"
                ,
                Name = "sled 45в° leg press"
                ,
                SetsPlan = "3 sets 12-15 reps"
                ,
                Target = "glutes"
                ,
                Plan = "Leg Day"
                ,
                IsActive = true
            });
            Insert.IntoTable(tableName: "Exercise").Row(new
            {
                Id = Guid.Parse("4cc87573-e6d0-4585-9b85-1a18c65afcff")
                ,
                BodyPart = "upper legs"
                ,
                Equipment = "barbell"
                ,
                GifUrl = "https://res.cloudinary.com/dxx6cjnjj/image/upload/v1685982758/0032_iz3lo5.gif"
                ,
                Name = "barbell deadlift"
                ,
                SetsPlan = "3 sets 12-15 reps"
                ,
                Target = "glutes"
                ,
                Plan = "Leg Day"
                ,
                IsActive = true
            });
            Insert.IntoTable(tableName: "Exercise").Row(new
            {
                Id = Guid.Parse("de6fee60-1ec4-494d-95cb-166cde6c8197")
                ,
                BodyPart = "chest"
                ,
                Equipment = "dumbbell"
                ,
                GifUrl = "https://res.cloudinary.com/dxx6cjnjj/image/upload/v1685980157/0314_lqutb9.gif"
                ,
                Name = "dumbbell incline bench press"
                ,
                SetsPlan = "4 sets 8-12 reps"
                ,
                Target = "pectorals"
                ,
                Plan = "Chest"
                ,
                IsActive = true
            });
            Insert.IntoTable(tableName: "Exercise").Row(new
            {
                Id = Guid.Parse("8c187cd6-d762-418e-b6c8-d19305ffddd2")
                ,
                BodyPart = "Chest"
                ,
                Equipment = "barbell"
                ,
                GifUrl = "https://res.cloudinary.com/dxx6cjnjj/image/upload/v1685980739/0025_finwsl.gif"
                ,
                Name = "barbell bench press"
                ,
                SetsPlan = "4 sets 8-12 reps"
                ,
                Target = "pectorals"
                ,
                Plan = "Chest"
                ,
                IsActive = true
            });
            Insert.IntoTable(tableName: "Exercise").Row(new
            {
                Id = Guid.Parse("8502c2c5-bb7d-494b-96eb-31282abda4c7")
                ,
                BodyPart = "Chest"
                ,
                Equipment = "leverage machine"
                ,
                GifUrl = "https://res.cloudinary.com/dxx6cjnjj/image/upload/v1685981514/0596_s0ehiw.gif"
                ,
                Name = "lever seated fly"
                ,
                SetsPlan = "3 sets 12-15 reps"
                ,
                Target = "pectorals"
                ,
                Plan = "Chest"
                ,
                IsActive = true
            });
            Insert.IntoTable(tableName: "Exercise").Row(new
            {
                Id = Guid.Parse("94185447-e04d-4e6e-9ce8-0137643ee33d")
                ,
                BodyPart = "Chest"
                ,
                Equipment = "body weight"
                ,
                GifUrl = "https://res.cloudinary.com/dxx6cjnjj/image/upload/v1685982895/0251_rmnyew.gif"
                ,
                Name = "chest dip"
                ,
                SetsPlan = "3 sets 12-15 reps"
                ,
                Target = "pectorals"
                ,
                Plan = "Chest"
                ,
                IsActive = true
            });
            Insert.IntoTable(tableName: "Exercise").Row(new
            {
                Id = Guid.Parse("cc3bd704-4941-48f6-a477-302a5fd48295")
                ,
                BodyPart = "back"
                ,
                Equipment = "cable"
                ,
                GifUrl = "https://res.cloudinary.com/dxx6cjnjj/image/upload/v1685980846/0150_dpfo7j.gif"
                ,
                Name = "cable bar lateral pulldown"
                ,
                SetsPlan = "4 sets 8-12 reps"
                ,
                Target = "lats"
                ,
                Plan = "Back"
                ,
                IsActive = true
            });
            Insert.IntoTable(tableName: "Exercise").Row(new
            {
                Id = Guid.Parse("a8496847-8e66-426a-8295-45e8832f479f")
                ,
                BodyPart = "back"
                ,
                Equipment = "barbell"
                ,
                GifUrl = "https://res.cloudinary.com/dxx6cjnjj/image/upload/v1685983001/0027_rxfrqh.gif"
                ,
                Name = "barbell bent over row"
                ,
                SetsPlan = "4 sets 8-12 reps"
                ,
                Target = "upper back"
                ,
                Plan = "Back"
                ,
                IsActive = true
            });
            Insert.IntoTable(tableName: "Exercise").Row(new
            {
                Id = Guid.Parse("f60699b0-aa5b-4510-adf8-871f7d52b6e5")
                ,
                BodyPart = "back"
                ,
                Equipment = "dumbbell"
                ,
                GifUrl = "https://res.cloudinary.com/dxx6cjnjj/image/upload/v1685983055/0293_yx5xy4.gif"
                ,
                Name = "dumbbell bent over row"
                ,
                SetsPlan = "3 sets 12-15 reps"
                ,
                Target = "upper back"
                ,
                Plan = "Back"
                ,
                IsActive = true
            });
            Insert.IntoTable(tableName: "Exercise").Row(new
            {
                Id = Guid.Parse("46fff16b-5d95-4a52-9d02-10b024b58469")
                ,
                BodyPart = "back"
                ,
                Equipment = "cable"
                ,
                GifUrl = "https://res.cloudinary.com/dxx6cjnjj/image/upload/v1685983100/0180_rpldls.gif"
                ,
                Name = "cable low seated row"
                ,
                SetsPlan = "3 sets 12-15 reps"
                ,
                Target = "upper back"
                ,
                Plan = "Back"
                ,
                IsActive = true
            });
            Insert.IntoTable(tableName: "Exercise").Row(new
            {
                Id = Guid.Parse("c8d2ac11-bb3b-4836-a41f-abad2af8a02c")
                ,
                BodyPart = "waist"
                ,
                Equipment = "body weight"
                ,
                GifUrl = "https://res.cloudinary.com/dxx6cjnjj/image/upload/v1685983142/0003_myvuti.gif"
                ,
                Name = "air bike"
                ,
                SetsPlan = "4 sets 30 reps"
                ,
                Target = "abs"
                ,
                Plan = "abs"
                ,
                IsActive = true
            });
            Insert.IntoTable(tableName: "Exercise").Row(new
            {
                Id = Guid.Parse("bbdf422f-7b43-48ea-9f5a-f0895fd9bd85")
                ,
                BodyPart = "waist"
                ,
                Equipment = "assisted"
                ,
                GifUrl = "https://res.cloudinary.com/dxx6cjnjj/image/upload/v1685983174/0013_hsrks6.gif"
                ,
                Name = "assisted lying leg raise with throw down"
                ,
                SetsPlan = "4 sets 30 reps"
                ,
                Target = "abs"
                ,
                Plan = "abs"
                ,
                IsActive = true
            });
            Insert.IntoTable(tableName: "Exercise").Row(new
            {
                Id = Guid.Parse("a7a44daa-7c11-4889-a3ef-a862bb2e36cb")
                ,
                BodyPart = "shoulders"
                ,
                Equipment = "barbell"
                ,
                GifUrl = "https://res.cloudinary.com/dxx6cjnjj/image/upload/v1685981434/1456_gy3ago.gif"
                ,
                Name = "barbell standing close grip military press"
                ,
                SetsPlan = "4 sets 8-12 reps"
                ,
                Target = "delts"
                ,
                Plan = "Shoulder"
                ,
                IsActive = true
            });
            Insert.IntoTable(tableName: "Exercise").Row(new
            {
                Id = Guid.Parse("8ca0f48e-a87c-4bcf-9820-9c5516c88b0f")
                ,
                BodyPart = "shoulders"
                ,
                Equipment = "dumbbell"
                ,
                GifUrl = "https://res.cloudinary.com/dxx6cjnjj/image/upload/v1685980944/0334_q1scij.gif"
                ,
                Name = "dumbbell lateral raise"
                ,
                SetsPlan = "4 sets 8-12 reps"
                ,
                Target = "delts"
                ,
                Plan = "Shoulder"
                ,
                IsActive = true
            });
            Insert.IntoTable(tableName: "Exercise").Row(new
            {
                Id = Guid.Parse("a03fcb46-50ed-4057-8c54-fcae9a4bea6d")
                ,
                BodyPart = "shoulders"
                ,
                Equipment = "dumbbell"
                ,
                GifUrl = "https://res.cloudinary.com/dxx6cjnjj/image/upload/v1685983338/0310_mv8xl1.gif"
                ,
                Name = "dumbbell front raise"
                ,
                SetsPlan = "4 sets 8-12 reps"
                ,
                Target = "delts"
                ,
                Plan = "Shoulder"
                ,
                IsActive = true
            });
            Insert.IntoTable(tableName: "Exercise").Row(new
            {
                Id = Guid.Parse("e66e226a-56d9-4247-8172-98b7d57b52dc")
                ,
                BodyPart = "shoulders"
                ,
                Equipment = "dumbbell"
                ,
                GifUrl = "https://res.cloudinary.com/dxx6cjnjj/image/upload/v1685983402/0437_mglwlx.gif"
                ,
                Name = "dumbbell upright row"
                ,
                SetsPlan = "3 sets 12-15 reps"
                ,
                Target = "delts"
                ,
                Plan = "Shoulder"
                ,
                IsActive = true
            });
            Insert.IntoTable(tableName: "Exercise").Row(new
            {
                Id = Guid.Parse("21f73f02-db0e-408a-bf6a-2cb7215284c8")
                ,
                BodyPart = "shoulders"
                ,
                Equipment = "dumbbell"
                ,
                GifUrl = "https://res.cloudinary.com/dxx6cjnjj/image/upload/v1685983559/0406_qm5vtz.gif"
                ,
                Name = "dumbbell shrug"
                ,
                SetsPlan = "3 sets 12-15 reps"
                ,
                Target = "traps"
                ,
                Plan = "Shoulder"
                ,
                IsActive = true
            });
        }

    }
}
