using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MZ_Lab_MVC.Models;

namespace MZ_Lab_MVC.Data
{
    public static class MZLabDbContextInitializer
    {
        public static void Initialize(this MZLabDbContext context)
        {
            context.Database.EnsureCreated();

            if (context.AcademicArticles.Any())
            {
                return;
            }

            var academicArticles = new List<AcademicArticle>()
            {

                new AcademicArticle()
                {
                    Title = "出海 絢子, 三木 良介, 宮崎 佳典, 厨子 光政, 法月 健, 英単語並び替え問題におけるマウス軌跡再現および迷い抽出を志向した履歴検索Webアプリケーション開発, 日本e-Learning学会論文誌, Vol.13, pp. 24-31 (2013). 2013.7",
                    CoverImgUrl = "~/img/ac1.jpg",
                    PostTime = Convert.ToDateTime("06/06/2013 22:00:00")
                },
                new AcademicArticle()
                {
                    Title = "山本 昇平, 宮崎 佳典, 技術文献コーパスを用いた英文書作成支援ツールの開発 －類似文検索機能とパターン検索機能－,統計数理研究所共同研究リポート 295, pp. 71-95 (2013). 2013.3",
                    CoverImgUrl = "~/img/ac2.jpg",
                    PostTime = Convert.ToDateTime("03/25/2013 12:10:00")
                },
                new AcademicArticle()
                {
                    Title = "宮崎 佳典, 渡部 孝幸, 林 佳樹, 導出規則に着目した証明視覚化・式変形支援システムの提案, 京都大学数理解析研究所研究集会「数学ソフトウェアと教育」, (2012). 於 京都大学数理解析研究所 2012.8",
                    CoverImgUrl = "~/img/ac3.jpg",
                    PostTime = Convert.ToDateTime("08/19/2012 21:15:00")
                },

            };

            context.AcademicArticles.AddRange(academicArticles);
            context.SaveChanges();
        }
    }
}
