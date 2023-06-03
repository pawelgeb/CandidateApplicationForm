﻿using AutoMapper;
using CandidateApplicationFormAPI.Entities;
using CandidateApplicationFormAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace CandidateApplicationFormAPI.Services
{
    public class AttachFileService : IAttachFileService
    {
        private readonly IMapper _mapper;
        private readonly ApplicationFormDbContext _context;
        public AttachFileService(ApplicationFormDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        //zostaw ten sposób!!
        //public CoverLetter UploadCoverLetter(string filePath)
        //{
        //    CreateCoverLetterDTO letter = new CreateCoverLetterDTO();
        //    string[] nameArray = filePath.Split('/');
        //    letter.Name = nameArray[nameArray.Length - 1];
        //    string[] formatArray = filePath.Split('.');
        //    letter.ContentType = formatArray[1];
        //    var filePathRead = Path.GetFullPath((new Uri(filePath)).LocalPath);
        //    letter.Data = File.ReadAllBytes(filePathRead);
        //    var letterDb = _mapper.Map<CoverLetter>(letter);
        //    return letterDb;
        //}

        public CoverLetter UploadCoverLetter(IFormFile file)
        {
            CreateCoverLetterDTO letter = new CreateCoverLetterDTO();
            var data = new byte[file.Length];
            letter.Name = file.FileName;
            letter.ContentType = file.ContentType;
            letter.Data = data;
            var letterDb = _mapper.Map<CoverLetter>(letter);
            return letterDb;
        }


        public void UpdateCoverLetter(string filePath, int idForm)
        {
            var letter = _context.CoverLetters.FirstOrDefault(p => p.ApplicationFormId == idForm);
            letter.ApplicationFormId = idForm;
            string[] nameArray = filePath.Split('/');
            letter.Name = nameArray[nameArray.Length - 1];
            string[] formatArray = filePath.Split('.');
            letter.ContentType = formatArray[1];
            var filePathRead = Path.GetFullPath((new Uri(filePath)).LocalPath);
            letter.Data = File.ReadAllBytes(filePathRead);
            var letterDb = _mapper.Map<CoverLetter>(letter);
            _context.Update(letterDb);
            _context.SaveChanges();

        }

        public void DeleteCoverLetter(int idForm)
        {
            var letter = _context.CoverLetters.FirstOrDefault(p => p.ApplicationFormId == idForm);
            _context.Remove(letter);

        }

        public List<Resume> UploadResume(string resumePath)
        {
            List<Resume> list = new List<Resume>();
            var resumeFirst = AddResume(resumePath);
            list.Add(resumeFirst);
            return list;
        }

        public Resume AddResume(string filePath)
        {
            CreateResumeDTO resume = new CreateResumeDTO();
            string[] nameArray = filePath.Split('/');
            resume.Name = nameArray[nameArray.Length - 1];
            string[] formatArray = filePath.Split('.');
            resume.ContentType = formatArray[1];
            resume.Data = File.ReadAllBytes(filePath);
            var resumeDb = _mapper.Map<Resume>(resume);
            return resumeDb;
        }

        public List<Resume> AddSecondResume(int idForm, string filePath)
        {
            var formResume = _context.ApplicationForms.FirstOrDefault(p => p.Id == idForm);
            CreateResumeDTO resume = new CreateResumeDTO();
            string[] nameArray = filePath.Split('/');
            resume.Name = nameArray[nameArray.Length - 1];
            string[] formatArray = filePath.Split('.');
            resume.ContentType = formatArray[1];
            resume.Data = File.ReadAllBytes(filePath);
            var resumeDb = _mapper.Map<Resume>(resume);
            formResume.Resumes.Add(resumeDb);
            _context.Update(formResume);
            _context.SaveChanges();
            return formResume.Resumes;
        }

        //public void UpdateResume(string filePath, int idForm)
        //{
        //    var formToUpdateResume = _context.ApplicationForms.FirstOrDefault(x => x.Id == idForm);

        //}

        //public void DeleteResume(int idForm)
        //{
        //    var formToAddResume = _context.ApplicationForms.FirstOrDefault(x => x.Id == idForm);

        //}

    }
}