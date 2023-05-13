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
                GifUrl = "http://d205bpvrqc9yn1.cloudfront.net/0314.gif"
                ,
                Name = "dumbbell incline bench press"
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
                GifUrl = "http://d205bpvrqc9yn1.cloudfront.net/0025.gif"
                ,
                Name = "barbell bench press"
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
                GifUrl = "http://d205bpvrqc9yn1.cloudfront.net/0383.gif"
                ,
                Name = "dumbbell reverse fly"
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
                GifUrl = "http://d205bpvrqc9yn1.cloudfront.net/0150.gif"
                ,
                Name = "cable bar lateral pulldown"
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
                GifUrl = "http://d205bpvrqc9yn1.cloudfront.net/0294.gif"
                ,
                Name = "dumbbell biceps curl"
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
                GifUrl = "http://d205bpvrqc9yn1.cloudfront.net/0334.gif"
                ,
                Name = "dumbbell lateral raise"
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
                GifUrl = "http://d205bpvrqc9yn1.cloudfront.net/0043.gif"
                ,
                Name = "barbell full squat"
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
                GifUrl = "http://d205bpvrqc9yn1.cloudfront.net/0381.gif"
                ,
                Name = "dumbbell rear lunge"
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
                GifUrl = "http://d205bpvrqc9yn1.cloudfront.net/0585.gif"
                ,
                Name = "lever leg extension"
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
                GifUrl = "http://d205bpvrqc9yn1.cloudfront.net/0586.gif"
                ,
                Name = "lever lying leg curl"
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
                BodyPart = "chest"
                ,
                Equipment = "dumbbell"
                ,
                GifUrl = "http://d205bpvrqc9yn1.cloudfront.net/0314.gif"
                ,
                Name = "dumbbell incline bench press"
                ,
                Target = "pectorals"
                ,
                Plan = "Lower Body"
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
                GifUrl = "http://d205bpvrqc9yn1.cloudfront.net/1456.gif"
                ,
                Name = "barbell standing close grip military press"
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
                GifUrl = "http://d205bpvrqc9yn1.cloudfront.net/0334.gif"
                ,
                Name = "dumbbell lateral raise"
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
                GifUrl = "http://d205bpvrqc9yn1.cloudfront.net/0596.gif"
                ,
                Name = "lever seated fly"
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
                GifUrl = "http://d205bpvrqc9yn1.cloudfront.net/0149.gif"
                ,
                Name = "cable alternate triceps extension"
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
                GifUrl = "http://d205bpvrqc9yn1.cloudfront.net/0194.gif"
                ,
                Name = "cable overhead triceps extension (rope attachment)"
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
                GifUrl = "http://d205bpvrqc9yn1.cloudfront.net/0150.gif"
                ,
                Name = "cable bar lateral pulldown"
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
                GifUrl = "http://d205bpvrqc9yn1.cloudfront.net/0027.gif"
                ,
                Name = "barbell bent over row"
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
                GifUrl = "http://d205bpvrqc9yn1.cloudfront.net/1320.gif"
                ,
                Name = "cable rope crossover seated row"
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
                GifUrl = "http://d205bpvrqc9yn1.cloudfront.net/0602.gif"
                ,
                Name = "lever seated reverse fly"
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
                GifUrl = "http://d205bpvrqc9yn1.cloudfront.net/0294.gif"
                ,
                Name = "dumbbell biceps curl"
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
                GifUrl = "http://d205bpvrqc9yn1.cloudfront.net/0298.gif"
                ,
                Name = "dumbbell cross body hammer curl"
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
                GifUrl = "http://d205bpvrqc9yn1.cloudfront.net/0043.gif"
                ,
                Name = "barbell full squat"
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
                GifUrl = "http://d205bpvrqc9yn1.cloudfront.net/0381.gif"
                ,
                Name = "dumbbell rear lunge"
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
                GifUrl = "http://d205bpvrqc9yn1.cloudfront.net/0585.gif"
                ,
                Name = "lever leg extension"
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
                GifUrl = "http://d205bpvrqc9yn1.cloudfront.net/0586.gif"
                ,
                Name = "lever lying leg curl"
                ,
                Target = "hamstrings"
                ,
                Plan = "Leg Day"
                ,
                IsActive = true
            });
            Insert.IntoTable(tableName: "Exercise").Row(new
            {
                Id = Guid.Parse("61ba9dea-4f3d-4553-907c-d1e885f8527d")
                ,
                BodyPart = "chest"
                ,
                Equipment = "dumbbell"
                ,
                GifUrl = "http://d205bpvrqc9yn1.cloudfront.net/0314.gif"
                ,
                Name = "dumbbell incline bench press"
                ,
                Target = "pectorals"
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
                GifUrl = "http://d205bpvrqc9yn1.cloudfront.net/0739.gif"
                ,
                Name = "sled 45в° leg press"
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
                GifUrl = "http://d205bpvrqc9yn1.cloudfront.net/0032.gif"
                ,
                Name = "barbell deadlift"
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
                GifUrl = "http://d205bpvrqc9yn1.cloudfront.net/0314.gif"
                ,
                Name = "dumbbell incline bench press"
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
                GifUrl = "http://d205bpvrqc9yn1.cloudfront.net/0025.gif"
                ,
                Name = "barbell bench press"
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
                GifUrl = "http://d205bpvrqc9yn1.cloudfront.net/0596.gif"
                ,
                Name = "lever seated fly"
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
                GifUrl = "http://d205bpvrqc9yn1.cloudfront.net/0251.gif"
                ,
                Name = "chest dip"
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
                GifUrl = "http://d205bpvrqc9yn1.cloudfront.net/0150.gif"
                ,
                Name = "cable bar lateral pulldown"
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
                GifUrl = "http://d205bpvrqc9yn1.cloudfront.net/0027.gif"
                ,
                Name = "barbell bent over row"
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
                GifUrl = "http://d205bpvrqc9yn1.cloudfront.net/0293.gif"
                ,
                Name = "dumbbell bent over row"
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
                GifUrl = "http://d205bpvrqc9yn1.cloudfront.net/0180.gif"
                ,
                Name = "cable low seated row"
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
                GifUrl = "http://d205bpvrqc9yn1.cloudfront.net/0003.gif"
                ,
                Name = "air bike"
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
                GifUrl = "http://d205bpvrqc9yn1.cloudfront.net/0013.gif"
                ,
                Name = "assisted lying leg raise with throw down"
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
                GifUrl = "http://d205bpvrqc9yn1.cloudfront.net/1456.gif"
                ,
                Name = "barbell standing close grip military press"
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
                GifUrl = "http://d205bpvrqc9yn1.cloudfront.net/0334.gif"
                ,
                Name = "dumbbell lateral raise"
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
                GifUrl = "http://d205bpvrqc9yn1.cloudfront.net/0310.gif"
                ,
                Name = "dumbbell front raise"
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
                GifUrl = "http://d205bpvrqc9yn1.cloudfront.net/0437.gif"
                ,
                Name = "dumbbell upright row"
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
                GifUrl = "http://d205bpvrqc9yn1.cloudfront.net/0406.gif"
                ,
                Name = "dumbbell shrug"
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
