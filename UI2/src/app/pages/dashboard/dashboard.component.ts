import { AuthService } from '../../services/auth.service';
import { ChangeDetectionStrategy, Component, OnInit } from '@angular/core';
import { AdvertisementService } from '../../services/advertisement.service';
import { BehaviorSubject, Observable } from 'rxjs';
import { switchMap } from 'rxjs/operators';
import { GetPagedContentResponseModel } from '../../models/advertisement/get-paged-content-response-model';
import { ActivatedRoute } from '@angular/router';
import { Router } from '@angular/router';
import { TagService } from '../../services/tag.service';
import { ITag } from 'src/app/models/tag/tag-model';
import { isNullOrUndefined } from 'util';

@Component({
  selector: 'app-dashboard',
  templateUrl: './dashboard.component.html',
  styleUrls: ['./dashboard.component.scss'],
  changeDetection: ChangeDetectionStrategy.OnPush
})

export class DashboardComponent implements OnInit {
  response$: Observable<GetPagedContentResponseModel>;
  isAuth = this.authService.isAuth;
  tags$: Observable<ITag[]>;

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
              private tagService: TagService) {
  }

  ngOnInit() {
    
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