using FluentValidation;
using Sev1.UserFiles.Application.Contracts.UserFile;
using Sev1.UserFiles.Application.Validators.Base;

namespace Sev1.UserFiles.Application.Validators.UserFile
{
    /// <summary>
    /// Валидатор DTO при создании объявления
    /// </summary>
    public class UserFileCreateDtoValidator : NullReferenceAbstractValidator<UserFileCreateDto>
    {
        public UserFileCreateDtoValidator()
        {
            // Общая проверка
            RuleFor(x => x)
                .NotNull()
                .NotEmpty().WithMessage("UserFileCreateDto is null!");

            // Название объявления
            RuleFor(x => x.FileName)
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
            RuleFor(x => x.FileDescription)
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

            // Пользователь Id
            RuleFor(x => x.OwnerId)
                .NotNull()
                .NotEmpty().WithMessage("OwnerId не заполнен!");
        }
    }
}