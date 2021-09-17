﻿using FluentValidation;
using Sev1.Advertisements.Application.Contracts.Advertisement;
using Sev1.Advertisements.Application.Validators.Base;
using Sev1.Advertisements.Application.Validators.Tag;

namespace Sev1.Advertisements.Application.Validators.Advertisement
{
    /// <summary>
    /// Валидатор DTO при создании объявления
    /// </summary>
    public class AdvertisementCreateDtoValidator : NullReferenceAbstractValidator<AdvertisementCreateDto>
    {
        public AdvertisementCreateDtoValidator()
        {
            // Общая проверка
            RuleFor(x => x)
                .NotNull()
                .NotEmpty().WithMessage("AdvertisementCreateDto is null!");

            // Название объявления
            RuleFor(x => x.Title)
                .NotNull()
                .NotEmpty().WithMessage("Title не заполнен!")

                // Протестировать тут: https://regex101.com/
                // Тест: "Продаются утята, котята, 3 коровы(?) и трактор!"
                // "^": указывает на начало строки;
                // "$": указывает на конец строки;
                // "^"..."$": нужно, чтобы шаблон охватывал строку от начала и до конца;
                // "+": квантификатор "одно или более вхождений набора[]"
                // "[]": набор:
                // или "а-яА-ЯёЁ": диапазон русских букв;
                // или "\w": символы латиницы, цифры и подчеркивание;
                // или "\s": пробел, табуляция, перенос строки;
                // или ".?!)(,:-": знаки препинания.
                .Matches(@"^[а-яА-ЯёЁ\w\s.?!)(,:-]+$")
                .MaximumLength(100);

            // Текст объявления
            RuleFor(x => x.Body)
                .NotNull()
                .NotEmpty().WithMessage("Body не заполнен!")

                // Протестировать тут: https://regex101.com/
                // Тест: "Продаются утята, котята, 3 коровы(?) и трактор!"
                // "^": указывает на начало строки;
                // "$": указывает на конец строки;
                // "^"..."$": нужно, чтобы шаблон охватывал строку от начала и до конца;
                // "+": квантификатор "одно или более вхождений набора[]"
                // "[]": набор:
                // или "а-яА-ЯёЁ": диапазон русских букв;
                // или "\w": символы латиницы, цифры и подчеркивание;
                // или "\s": пробел, табуляция, перенос строки;
                // или ".?!)(,:-": знаки препинания.
                .Matches(@"^[а-яА-ЯёЁ\w\s.?!)(,:-]+$")
                .MinimumLength(5)
                .MaximumLength(1000);

            // Цена
            RuleFor(x => x.Price)
                .NotNull()
                .NotEmpty().WithMessage("Price не заполнен!")
                .InclusiveBetween(0, decimal.MaxValue);

            // Id категории
            RuleFor(x => x.CategoryId)
                .NotNull()
                .NotEmpty().WithMessage("CategoryId не заполнен!")
                .InclusiveBetween(1, int.MaxValue);

            // Пользователь Id
            RuleFor(x => x.OwnerId)
                .NotNull()
                .NotEmpty().WithMessage("OwnerId не заполнен!");

            // Проверка массива строк TagBodies
            RuleForEach(x => x.TagBodies).SetValidator(new TagBodyValidator());
        }
    }
}
