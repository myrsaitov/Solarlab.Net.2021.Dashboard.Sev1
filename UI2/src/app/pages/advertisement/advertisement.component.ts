import {Component, OnInit, TemplateRef} from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { ActivatedRoute, Router } from '@angular/router';
import { map, pluck, take } from 'rxjs/operators';
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
import { IUser } from 'src/app/models/user/user-model';
import { ICategory } from 'src/app/models/category/category-model';
import { IRegion } from 'src/app/models/region/region-model';
import { RegionService } from 'src/app/services/region.service';

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
  advertisementOwnerName: string;
  isAuth = this.authService.isAuth;
  isEditable: boolean;
  response$: Observable<GetPagedCommentResponseModel>;
  tags$: Observable<ITag[]>;
  users$: Observable<IUser[]>;
  users: IUser[];
  categories$: Observable<ICategory[]>;
  categories: ICategory[];
  regions$: Observable<IRegion[]>;
  regions: IRegion[];
  advertisementStatus: string;

  private commentsFilterSubject$ = new BehaviorSubject({
    contentId: 1,
    pageSize: 10,
    page: 0
  });
  commentsFilterChange$ = this.commentsFilterSubject$.asObservable();

  constructor(private fb: FormBuilder,
              private route: ActivatedRoute,
              private router: Router,
              private advertisementService: AdvertisementService,
              private authService: AuthService,
              private toastService: ToastService,
              private categoryService: CategoryService,
              private commentService: CommentService,
              private modalService: NgbModal,
              private tagService: TagService,
              private userService: UserService,
              private regionService: RegionService) {
  }

  ngOnInit() {

    // Подписка на категории
    this.categories$ = this.categoryService.getCategoryList({
      pageSize: 1000,
      page: 0,
    });
    this.categories$.subscribe(categories => this.categories = categories);

    // Подписка на пользователей
    this.users$ = this.userService.getUserList({
      pageSize: 1000,
      page: 0,
    });
    this.users$.subscribe(users => this.users = users);

    // Подписка на таги
    this.tags$ = this.tagService.getTagList({
      pageSize: 1000,
      page: 0,
    });
    
    // Подписка на регионы
    this.regions$ = this.regionService.getRegionList({
      pageSize: 1000,
      page: 0,
    });
    this.regions$.subscribe(regions => this.regions = regions);

    // Валидация формы
    this.form = this.fb.group({
      commentBody: ['', Validators.required]
    });

    this.route.params.pipe(pluck('id')).subscribe(advertisementId => {
      this.commentsFilterSubject$.value.contentId = advertisementId;
      this.advertisementService.getAdvertisementById(advertisementId).subscribe(advertisement => {
        if (isNullOrUndefined(advertisement)) {
          this.router.navigate(['/']);
          return;
        }
        this.advertisement = advertisement;

        // Возвращает UserName пользоватeля по идентификатору
        this.advertisementOwnerName =  this.getUserNameById(advertisement.ownerId);

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
            this.router.navigate(['/']);
            return;
          }

          this.advertisement.category = category;
          this.advertisementStatus = this.getStatusNameByValue(this.advertisement.status);

          });
        });
    });

    // Комментарии
    this.response$ = this.commentsFilterChange$
      .pipe( // pipe - применить указанное действие ко всем элементам конвейера
        switchMap(commentsFilter => this.commentService.getCommentsList(commentsFilter)
      ));
  }

  get commentsFilter() {
    this.commentsFilterSubject$.value.contentId = this.advertisement.id;
    return this.commentsFilterSubject$.value;
  }

    // Возвращает имя пользователя по идентификатору
  getUserNameById(userId: string){
      return this.users.find(s => s.userId === userId).userName;
  }

  // Возвращает имя категории по идентификатору
  getCategoryNameById(categoryId: number){
    return this.categories.find(s => s.id === categoryId).name;
  }

  // Возвращает имя региона по идентификатору
  getRegionNameById(regionId: number){
    return this.regions.find(s => s.id === regionId).name;
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
    
      this.router.navigate(['/',this.advertisement.id]);

      this.commentsFilterSubject$.next({
        ...this.commentsFilter
      })
    });
  }

  getContentByTag(tag: string){
    this.router.navigate(['/'], { queryParams: { tag: tag } });
  }
  getContentByCategoryId(categoryId: number){
    this.router.navigate(['/'], { queryParams: { categoryId: categoryId } });
  }
  getContentByUserName(userName: string){
    this.router.navigate(['/'], { queryParams: { userName: userName } });
  }




  delete(id: number) {
    this.advertisementService.delete(id).pipe(take(1)).subscribe(() => {
      this.toastService.show('Объявление успешено удалено', {classname: 'bg-success text-light'});
      this.router.navigate(['/']);
    });
  }

  openDeleteModal(content: TemplateRef<any>) {
    this.modalService.open(content, {centered: true});
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
    
      this.router.navigate(['/',this.advertisement.id]);

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