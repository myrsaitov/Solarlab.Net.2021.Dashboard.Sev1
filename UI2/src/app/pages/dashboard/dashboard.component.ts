import { AuthService } from '../../services/auth.service';
import { ChangeDetectionStrategy, Component, OnInit } from '@angular/core';
import { AdvertisementService } from '../../services/advertisement.service';
import { BehaviorSubject, Observable } from 'rxjs';
import { switchMap } from 'rxjs/operators';
import { GetPagedContentResponseModel } from '../../models/advertisement/get-paged-content-response-model';
import { ActivatedRoute } from '@angular/router';
import { Router } from '@angular/router';
import { UserService } from 'src/app/services/user.service';
import { IUser } from 'src/app/models/user/user-model';
import { ICategory } from 'src/app/models/category/category-model';
import { CategoryService } from 'src/app/services/category.service';
import { ITag } from 'src/app/models/tag/tag-model';
import { TagService } from 'src/app/services/tag.service';
import { IUserFile } from 'src/app/models/user-files/userfile-model';
import { UserFilesService } from 'src/app/services/userfiles.service';
import { IRegion } from 'src/app/models/region/region-model';
import { RegionService } from 'src/app/services/region.service';

// The @Component decorator identifies the class immediately below it as a component class, and specifies its metadata.
@Component({
  selector: 'app-dashboard',
  templateUrl: './dashboard.component.html',
  styleUrls: ['./dashboard.component.scss'],
  changeDetection: ChangeDetectionStrategy.OnPush
})

export class DashboardComponent implements OnInit {
  response$: Observable<GetPagedContentResponseModel>;
  isAuth = this.authService.isAuth;
  users$: Observable<IUser[]>;
  users: IUser[];
  categories$: Observable<ICategory[]>;
  categories: ICategory[];
  tags$: Observable<ITag[]>;
  defaultImageUri: string = "https://vjoy.cc/wp-content/uploads/2019/07/3-5.jpg";
  userFiles$: Observable<IUserFile[]>;
  userFiles: IUserFile[];
  regions$: Observable<IRegion[]>;
  regions: IRegion[];
  
  private advertisementsFilterSubject$ = new BehaviorSubject({
    searchStr: null,
    ownerId: null,
    categoryId: null,
    tag: null,
    pageSize: 9,
    page: 0
  });
  advertisementsFilterChange$ = this.advertisementsFilterSubject$.asObservable();

  constructor(private authService: AuthService,
              private advertisementService: AdvertisementService,
              private route: ActivatedRoute,
              private readonly router: Router,
              private userService: UserService,
              private categoryService: CategoryService,
              private tagService: TagService,
              private userFilesService: UserFilesService,
              private regionService: RegionService) {
  }

  ngOnInit() {
    
    // Подписка на файлы
    this.userFiles$ = this.userFilesService.getUserFilesList({
      pageSize: 1000,
      page: 0,
    });
    this.userFiles$.subscribe(userFiles => {
      this.userFiles = userFiles;
    });   

    // Подписка на категории
    this.categories$ = this.categoryService.getCategoryList({
      pageSize: 1000,
      page: 0,
    });

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

    // Загружает сессию
    this.authService.loadSession();

    // Проверяет, произошла ли авторизация
    this.isAuth = this.authService.isAuth;

    // Обработка запроса с фильтрацией объявлений
    this.route.queryParams.subscribe(params => {
      this.advertisementsFilterSubject$.value.searchStr = null;
      this.advertisementsFilterSubject$.value.ownerId = null;
      this.advertisementsFilterSubject$.value.categoryId = null;
      this.advertisementsFilterSubject$.value.tag = null;

      if('searchStr' in params){
        this.advertisementsFilterSubject$.value.searchStr = params.searchStr;
      }
      else if('ownerId' in params){
        this.advertisementsFilterSubject$.value.ownerId = params.ownerId;
      }
      else if('categoryId' in params){
        this.advertisementsFilterSubject$.value.categoryId = params.categoryId;
      }
      else if('tag' in params){
        this.advertisementsFilterSubject$.value.tag = params.tag;
      }

      this.advertisementsFilterSubject$.next({
        ...this.advertisementsFilter
      });
    });

    // Возвращает список объявлений по фильтру
    this.response$ = this.advertisementsFilterChange$.pipe( // pipe - применить указанное действие ко всем элементам конвейера
      switchMap(advertisementsFilter => this.advertisementService.getAdvertisementsList(advertisementsFilter)
    ));
  }
  
  // Возвращает имя пользователя по идентификатору
  getUserNameById(userId: string){
    return this.users.find(s => s.userId === userId).userName;
  }

  // Возвращает имя региона по идентификатору
  getRegionNameById(regionId: number){
    return this.regions.find(s => s.id === regionId).name;
 }
 
  // Возвращает ссылку на файл по идентификатору
  getUserFileUriById(id: number){
    var file = this.userFiles.find(s => s.id === id);
    if (typeof file === 'undefined') {
      return "https://upload.wikimedia.org/wikipedia/commons/0/0a/No-image-available.png";
    }
    else {
      return file.filePath;
    }
  }

  // Выполняет запрос на поиск по категории
  getAdvertisementCategoryId(categoryId: number){
    this.router.navigate(['/'], { queryParams: { categoryId: categoryId } });
  }

  // Выполняет запрос на поиск по тагу
  getContentByTag(tag: string){
    this.router.navigate(['/'], { queryParams: { tag: tag } });
  }

  // Возвращает фильтр объявлений (параметры пагинации)
  get advertisementsFilter() {
    return this.advertisementsFilterSubject$.value;
  }

  // Обновляет страницу при изменении фильтра
  updateAdvertisementsFilterPage(page) {
    this.advertisementsFilterSubject$.next({
      ...this.advertisementsFilter,
      page
    });
  }
}