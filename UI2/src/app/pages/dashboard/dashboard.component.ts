import { AuthService } from '../../services/auth.service';
import { ChangeDetectionStrategy, Component, OnInit } from '@angular/core';
import { AdvertisementService } from '../../services/advertisement.service';
import { BehaviorSubject, Observable } from 'rxjs';
import { map, switchMap } from 'rxjs/operators';
import { GetPagedContentResponseModel } from '../../models/advertisement/get-paged-content-response-model';
import { ActivatedRoute } from '@angular/router';
import { Router } from '@angular/router';
import { TagService } from '../../services/tag.service';
import { ITag } from 'src/app/models/tag/tag-model';
import { UserService } from 'src/app/services/user.service';
import { IUser } from 'src/app/models/user/user-model';

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
  tags$: Observable<ITag[]>;
  tmpUserName: string;

  private advertisementsFilterSubject$ = new BehaviorSubject({
    searchStr: null,
    userName: null,
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
              private tagService: TagService,
              private userService: UserService) {
  }

  ngOnInit() {
    
    // Подписка на пользователей
    this.users$ = this.userService.getUserList({
      pageSize: 1000,
      page: 0,
    });

    // Подписка на таги
    this.tags$ = this.tagService.getTagList({
      pageSize: 1000,
      page: 0,
    });

    // Загружает сессию
    this.authService.loadSession();

    // Проверяет, произошла ли авторизация
    this.isAuth = this.authService.isAuth;

    this.route.queryParams.subscribe(params => {

      this.advertisementsFilterSubject$.value.searchStr = null;
      this.advertisementsFilterSubject$.value.userName = null;
      this.advertisementsFilterSubject$.value.categoryId = null;
      this.advertisementsFilterSubject$.value.tag = null;

      if('searchStr' in params){
        this.advertisementsFilterSubject$.value.searchStr = params.searchStr;
      }
      else if('userName' in params){
        this.advertisementsFilterSubject$.value.userName = params.userName;
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




      this.response$ = this.advertisementsFilterChange$.pipe( // pipe - применить указанное действие ко всем элементам конвейера
        switchMap(advertisementsFilter => this.advertisementService.getAdvertisementsList(advertisementsFilter)
      ));

  }
  
  // Возвращает имя пользователя по идентификатору
  getUserNameById(userId: string){
    this.users$
    .pipe(
      map(data => data
        .find(x => x.userId === userId)))
    .subscribe(res => {
      this.tmpUserName = res.userName
    }),this;
    
    console.log("*******************************************");
    console.log(this.tmpUserName);
    return this.tmpUserName;
  }

  getContentByTag(tag: string){
    this.router.navigate(['/'], { queryParams: { tag: tag } });
  }

  get advertisementsFilter() {
    return this.advertisementsFilterSubject$.value;
  }

  updateAdvertisementsFilterPage(page) {
    this.advertisementsFilterSubject$.next({
      ...this.advertisementsFilter,
      page
    });
  }
}