import {Component, OnInit, TemplateRef} from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { ActivatedRoute, Router } from '@angular/router';
import { pluck, take } from 'rxjs/operators';
import { AdvertisementService } from '../../services/advertisement.service';
import { CommentService } from '../../services/comment.service';
import { IAdvertisement } from '../../models/advertisement/i-advertisement';
import { AuthService } from '../../services/auth.service';
import { ToastService } from '../../services/toast.service';
import { CategoryService } from '../../services/category.service';
import { GetPagedCommentResponseModel } from '../../models/comment/get-paged-comment-response-model';
import { BehaviorSubject, Observable, Subscriber } from 'rxjs';
import { switchMap } from 'rxjs/operators';
import { ChangeDetectionStrategy } from '@angular/core';
import { CreateComment, ICreateComment } from '../../models/comment/comment-create-model';
import { NgbModal } from '@ng-bootstrap/ng-bootstrap';
import { TagService } from '../../services/tag.service';
import { ITag } from 'src/app/models/tag/tag-model';
import { isNullOrUndefined } from 'util';
import { UserService } from 'src/app/services/user.service';
import { ICategory } from 'src/app/models/category/category-model';
import { RegionService } from 'src/app/services/region.service';
import { EditAdvertisementStatus, IEditAdvertisementStatus } from 'src/app/models/advertisement/advertisement-status-edit-model';
import { UserFilesService } from 'src/app/services/userfiles.service';
import { IUserFile } from 'src/app/models/user-files/userfile-model';
import { RouterService } from 'src/app/services/router.service';

// The @Component decorator identifies the class immediately below it as a component class, and specifies its metadata.
@Component({
  selector: 'app-advertisement', // A CSS selector that tells Angular to create and insert an instance of this component wherever it finds the corresponding tag in template HTML
  templateUrl: './advertisement.component.html', // The module-relative address of this component's HTML template.
  styleUrls: ['./advertisement.component.scss'], // 
  changeDetection: ChangeDetectionStrategy.Default
})

export class AdvertisementComponent implements OnInit {
  form: FormGroup;
  advertisement: IAdvertisement;
  isAuth = this.authService.isAuth;
  isEditable: boolean;
  response$: Observable<GetPagedCommentResponseModel>;
  categories$: Observable<ICategory[]>;
  categories: ICategory[];
  advertisementStatus: string;
  advertisementId$ = this.route.params.pipe(pluck('id'));
  userFiles$: Observable<IUserFile[]>;
  userFiles: IUserFile[];
  userFilesSlides: string [] = [];
  userFilesSlidesIndex = 0;
  userFilesCount = 0;

  // Для показа FullScreen
  currentIndex: any = -1;
  showFlag: any = false;
  imageObject: Array<object> = [];

  private commentsFilterSubject$ = new BehaviorSubject({
    contentId: 1,
    pageSize: 10,
    page: 0
  });
  commentsFilterChange$ = this.commentsFilterSubject$.asObservable();

  constructor(
    private readonly fb: FormBuilder,
    private readonly route: ActivatedRoute,
    private readonly router: RouterService,
    private readonly advertisementService: AdvertisementService,
    private readonly authService: AuthService,
    private readonly toastService: ToastService,
    private readonly categoryService: CategoryService,
    private readonly commentService: CommentService,
    private readonly modalService: NgbModal,
    private readonly tagService: TagService,
    private readonly userService: UserService,
    private readonly userFilesService: UserFilesService,
    private readonly regionService: RegionService) {
  }

  ngOnInit() {

    // Подписка на категории
    this.categories$ = this.categoryService.getCategoryList({
      pageSize: 1000,
      page: 0,
    });
    this.categories$.subscribe(categories => this.categories = categories);

    // Подписка на файлы
    this.userFiles$ = this.userFilesService.getUserFilesList({
      pageSize: 1000,
      page: 0,
    });
    this.userFiles$.subscribe(userFiles => {
      this.userFiles = userFiles;
      // Инициализация объявления
      this.advertisementInit();
    });   

    // Валидация формы
    this.form = this.fb.group({
      commentBody: ['', Validators.required],
      status: ['', Validators.required]
    });



    // Комментарии
    this.response$ = this.commentsFilterChange$
      .pipe( // pipe - применить указанное действие ко всем элементам конвейера
        switchMap(commentsFilter => this.commentService.getCommentsList(commentsFilter)
      ));
  }

  // Инициализация объявления
  advertisementInit(){
    this.route.params.pipe(pluck('id')).subscribe(advertisementId => {
      this.commentsFilterSubject$.value.contentId = advertisementId;
      this.advertisementService.getAdvertisementById(advertisementId).subscribe(advertisement => {
        
        // Если объявление не найдено
        if (isNullOrUndefined(advertisement)) {
          this.router.goToMainPage();
          return;
        }
        this.advertisement = advertisement;
        
        // Загружает данные пользователя
        this.userService.getUserById(advertisement.ownerId);

        // Заполшняем слайдер и imageObject
        this.advertisement.userFiles.forEach(userFile => {
          var uri = this.getUserFileUriById(userFile);
          this.userFilesSlides.push(uri);
          var obj = {image: uri};
          this.imageObject.push(obj);
        });
        
        // Количество файлов к объявлению
        this.userFilesCount = this.advertisement.userFiles.length;

        // Устанавливаем значение статуса на форме
        this.status.patchValue(advertisement.status);

        // Если объявление принадлежит авторизированному пользователю, то разрешаем редактирование
        if(this.advertisement.ownerId == localStorage.getItem('userId')) {
          this.isEditable = true;
        }
        else {
          this.isEditable = false;
        }

        // Возвращаем имя категории по идентификатору
        this.categoryService.getCategoryById(this.advertisement.categoryId).subscribe(category => {
          if (isNullOrUndefined(category)) {
            this.router.goToMainPage();
            return;
          }

          this.advertisement.category = category;
          this.advertisementStatus = this.getStatusNameByValue(this.advertisement.status);
          });
        });
    });
  }


  get commentsFilter() {
    this.commentsFilterSubject$.value.contentId = this.advertisement.id;
    return this.commentsFilterSubject$.value;
  }

  // Карусель картинок
  // Возвращает слайд
  getUserFilesSlide() {
    return this.userFilesSlides[this.userFilesSlidesIndex];
  }
  // Переводит счетчик слайдов на предыдущий
  getUserFilesPrevSlide() {
    if (this.userFilesSlidesIndex === 0) {
      // Если дошли до самого левого, то переходим на самый правый
      this.userFilesSlidesIndex = this.userFilesSlides.length - 1;
    }
    else {
      this.userFilesSlidesIndex -= 1;
    }
  }
  // Переводит счетчик слайдов на следующий
  getUserFilesNextSlide() {
    if (this.userFilesSlidesIndex === this.userFilesSlides.length - 1) {
      // Если дошли до самого правого, то переходим на самый левый
      this.userFilesSlidesIndex = 0;
    }
    else {
      this.userFilesSlidesIndex += 1;
    }
  }
  // Выбирает слайд из превьюшки
  getUserFilesThisSlide(index: number) {
    this.userFilesSlidesIndex = index;
  }
  // Проверяет, выбран ли слайд
  getUserFilesSlideSelectedStatus(index: number) {
    return this.userFilesSlidesIndex === index;
  }
  // Проверяет, существуют ли файлы к данному объявлению
  getUserFilesExists() {
    return this.userFilesSlides.length > 0;
  }
  // Увеличивает картинку при зажатии мышкой

  showLightbox() {
    this.currentIndex = this.userFilesSlidesIndex;
    this.showFlag = true;
  }

  closeEventHandler() {
    this.showFlag = false;
    this.currentIndex = -1;
  }


  // Возвращает ссылку на файл по идентификатору
  getUserFileUriById(id: number){
    return this.userFiles.find(s => s.id === id).filePath;
  }
  
  // Возвращает имя категории по идентификатору
  getCategoryNameById(categoryId: number){
    return this.categories.find(s => s.id === categoryId).name;
  }

  // Возвращает статус объявления по значению
  getStatusNameByValue(value: number){
    switch(value) { 
      case 0: { 
         return "Активно"; 
         break; 
      } 
      case 1: { 
        return "Приостановлено"; 
        break; 
      } 
      case 2: { 
        return "Черновик"; 
        break; 
      }
      case 3: { 
        return "Удалено"; 
        break; 
      }
      case 4: { 
        return "Недопустимое содержание"; 
        break; 
      } 
      default: { 
        return "No Status!"; 
        break; 
      } 
    } 
  }

  get status() { return this.form.get('status'); }

  updateCommentsFilterPage(page) {
    this.commentsFilterSubject$.next({
      ...this.commentsFilter,
      page
    });
  }

  get commentBody() {
    return this.form.get('commentBody');
  }

  // Удалить комментарий
  delete_comment(){
    this.commentService.delete(1).pipe(take(1)).subscribe(() => {
      this.toastService.show('Комментарий успешено удален', {classname: 'bg-success text-light'});
    
      this.router.goToAdvertisementPageById(this.advertisement.id);

      this.commentsFilterSubject$.next({
        ...this.commentsFilter
      })
    });
  }

  // Обработка "Удалить объявление"
  delete(id: number) {
    this.advertisementService.delete(id).pipe(take(1)).subscribe(() => {
      this.toastService.show(
        'Объявление успешено удалено',
        {classname: 'bg-success text-light'});
      this.router.goToMainPage();
    });
  }

  // Вызов модальной формы "Подтвердите удаление"
  openDeleteModal(content: TemplateRef<any>) {
    this.modalService.open(content, {centered: true});
  }

  // Реакция на изменение статуса объявления
  onChange() {

    this.advertisementId$.pipe(switchMap(id => {
      const model: Partial<IEditAdvertisementStatus> = {
        id: +id,
        status: this.status.value,
      };

      return this.advertisementService.editStatus(new EditAdvertisementStatus(model));
    }), take(1)).subscribe((res) => {

        console.log("***************************************");
        console.log(res);
        this.status.patchValue(res);
        // Выдаёт всплывающее сообщение о результате
        this.toastService.show(
          'Статус успешно обновлён!',
          {classname: 'bg-success text-light'});
      });
  }

  // Добавить комментарий
  submit() {

    const model: Partial<ICreateComment> = {
      body: this.commentBody.value,
      contentId: this.advertisement.id,
      parentCommentId: null
    };

    if(model.body.length == 0)
    {
      return;
    }

    this.commentService.create(new CreateComment(model)).pipe(take(1)).subscribe(() => {
      this.toastService.show('Комментарий успешено добавлен', {classname: 'bg-success text-light'});
    
      this.router.goToAdvertisementPageById(this.advertisement.id);

      this.commentsFilterSubject$.next({
        ...this.commentsFilter
      })

    });

    // Валидаторы формы
    this.form = this.fb.group({
      commentBody: ['', Validators.required]
    });

  }
}