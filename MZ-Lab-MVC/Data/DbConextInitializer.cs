﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MZ_Lab_MVC.Models;
using Microsoft.AspNetCore.Identity;

namespace MZ_Lab_MVC.Data
{
    public interface IDbConextInitializer
    {
        void Initialize();
    }

    public class  DbContextInitializer:IDbConextInitializer
    {
        MZLabDbContext _mzLabDbContext;
        ApplicationDbContext _applicationDbContext;
        UserManager<ApplicationUser> _userManager;
        RoleManager<IdentityRole> _roleManager;
        

        public DbContextInitializer(MZLabDbContext mzLabDbContext,ApplicationDbContext applicationDbContext,UserManager<ApplicationUser> userManager,RoleManager<IdentityRole> roleManager)
        {
            _mzLabDbContext = mzLabDbContext;
            _applicationDbContext = applicationDbContext;
            _userManager = userManager;
            _roleManager = roleManager;
        }

        public void Initialize()
        {
            ApplicationDbContextInitialize();
            MZLabDbContextInitialize();
        }
        public async void  ApplicationDbContextInitialize()
        {
            //create database schema if none exists
            _applicationDbContext.Database.EnsureCreated();

            if (_applicationDbContext.Users.Any())
            {
                return;
            }

            //Create the default Admin account and apply the Administrator role
            string username = "Shizuoka.MZLab@gmail.com";
            string password = "Mzlab4575?";

            var user = new ApplicationUser { UserName = username, Email = username };
            var result = await _userManager.CreateAsync(user, password);
        }
        public void MZLabDbContextInitialize()
        {
            _mzLabDbContext.Database.EnsureCreated();

            if (_mzLabDbContext.AcademicArticles.Any())
            {
                return;
            }

            var members = new List<Member>()
            {
                new Member()
                {
                    FamilyName = "笹原 ",
                    GivenName = "陽子",
                    FamilyNamePronunciation = "Sasahara",
                    GivenNamePronunciation = "Youko",
                    AvatarUrl = "~/img/avatar1_120x120.png",
                    Major = "Comp Scienece",
                    Grade = "M2",
                    Introduction = "最近の趣味はアイロンで卵を焼くこと、</br>しかし、まだうまくできなくて...</br></br>今年もやる気が出れるように !",
                    Email = "Yoko@queens.com",
                    Remark = "Twitter: @YokoSama"
                },
                new Member()
                {
                    FamilyName = "Steven",
                    GivenName = "Diaz",
                    FamilyNamePronunciation = "ステイブン",
                    GivenNamePronunciation = "デイアズ",
                    AvatarUrl = "~/img/avatar2_120x120.png",
                    Major = "Infor Behavior",
                    Grade = "M1",
                    Introduction = "Hey, Guys! Nice to meet you!</br>We could do something really crazy here.</ br></ br>And, we gonna remember it.",
                    Email = "steven_diaz@meetsup.net",
                    Remark = "Facebook: @Steven_Diaz"
                },
                new Member()
                {
                    FamilyName = "榛名",
                    GivenName = "純",
                    FamilyNamePronunciation = "Haruna",
                    GivenNamePronunciation = "Jyuun",
                    AvatarUrl = "~/img/avatar3_120x120.png",
                    Major = "Infor Society",
                    Grade = "M1",
                    Introduction = "淡いものが好きのやつ。</br>いつもなんでも受け入れやすいやつ。</br>特に行動力がないやつ。</br>しかし、頼りになれるやつ。</br>",
                    Email = "crazy8@dotmail.net",
                    Remark = "do not use any social media currently."
                },
            };

            var academicArticles = new List<AcademicArticle>()
            {

                new AcademicArticle()
                {
                    Title = "出海 絢子, 三木 良介, 宮崎 佳典, 厨子 光政, 法月 健, 英単語並び替え問題におけるマウス軌跡再現および迷い抽出を志向した履歴検索Webアプリケーション開発, 日本e-Learning学会論文誌, Vol.13, pp. 24-31 (2013). 2013.7",
                    CoverImgUrl = "~/img/ac1.jpg",
                    PostTime = Convert.ToDateTime("06/06/2013 22:00:00"),
                    Editors = "出海 絢子, 三木 良介, 宮崎 佳典, 厨子 光政, 法月 健,"
                },
                new AcademicArticle()
                {
                    Title = "山本 昇平, 宮崎 佳典, 技術文献コーパスを用いた英文書作成支援ツールの開発 －類似文検索機能とパターン検索機能－,統計数理研究所共同研究リポート 295, pp. 71-95 (2013). 2013.3",
                    CoverImgUrl = "~/img/ac2.jpg",
                    PostTime = Convert.ToDateTime("03/25/2013 12:10:00"),
                    Editors = "山本 昇平, 宮崎 佳典, "
                },
                new AcademicArticle()
                {
                    Title = "宮崎 佳典, 渡部 孝幸, 林 佳樹, 導出規則に着目した証明視覚化・式変形支援システムの提案, 京都大学数理解析研究所研究集会「数学ソフトウェアと教育」, (2012). 於 京都大学数理解析研究所 2012.8",
                    CoverImgUrl = "~/img/ac3.jpg",
                    PostTime = Convert.ToDateTime("08/19/2012 21:15:00"),
                    Editors = "宮崎 佳典, 渡部 孝幸, 林 佳樹, "
                },

            };

            _mzLabDbContext.Members.AddRange(members);
            _mzLabDbContext.AcademicArticles.AddRange(academicArticles);
            _mzLabDbContext.SaveChanges();
        }
    }
}
