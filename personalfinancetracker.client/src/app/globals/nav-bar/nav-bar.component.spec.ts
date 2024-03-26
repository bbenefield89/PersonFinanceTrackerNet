import { ComponentFixture, TestBed } from '@angular/core/testing';
import { NavBarComponent } from './nav-bar.component';
import { Router } from '@angular/router';

describe('NavBarComponent', () => {
    let component: NavBarComponent;
    let fixture: ComponentFixture<NavBarComponent>;
    let router: Router;

    beforeEach(async () => {
        await TestBed.configureTestingModule({
            declarations: [NavBarComponent],
        }).compileComponents();

        fixture = TestBed.createComponent(NavBarComponent);
        component = fixture.componentInstance;
        router = TestBed.inject(Router);

        fixture.detectChanges();
    });

    it('should create', () => {
        expect(component).toBeTruthy();
    });

    it('should have correct href for logo link', () => {
        const linkElements: HTMLElement[] = fixture.nativeElement.querySelectorAll('a');
        const logoLink = Array.from(linkElements).find(element => element.textContent?.includes('Personal Finance Tracker'));
        expect(logoLink).not.toBeNull()
        expect(logoLink?.getAttribute("href")).toEqual("/")
    });

    it('should have correct href for home link', () => {
        const linkElements: HTMLElement[] = fixture.nativeElement.querySelectorAll('a');
        const homeLinks = Array.from(linkElements).filter(element => element.textContent?.includes('Home'));
        expect(homeLinks.length).toEqual(2)

        homeLinks.forEach(link => {
            expect(link).not.toBeNull()
            expect(link?.getAttribute("href")).toEqual("/")
        })
    });

    it('should have correct href for About link', () => {
        const linkElements: HTMLElement[] = fixture.nativeElement.querySelectorAll('a');
        const aboutLinks = Array.from(linkElements).filter(element => element.textContent?.includes('About'));
        expect(aboutLinks.length).toEqual(2);

        aboutLinks.forEach(link => {
            expect(link).not.toBeNull();
            expect(link.getAttribute("href")).toEqual("/about");
        });
    });

    it('should have correct href for Services link', () => {
        const linkElements: HTMLElement[] = fixture.nativeElement.querySelectorAll('a');
        const servicesLinks = Array.from(linkElements).filter(element => element.textContent?.includes('Services'));
        expect(servicesLinks.length).toEqual(2);

        servicesLinks.forEach(link => {
            expect(link).not.toBeNull();
            expect(link.getAttribute("href")).toEqual("/services");
        });
    });

    it('should have correct href for Contact link', () => {
        const linkElements: HTMLElement[] = fixture.nativeElement.querySelectorAll('a');
        const contactLinks = Array.from(linkElements).filter(element => element.textContent?.includes('Contact'));
        expect(contactLinks.length).toEqual(2);

        contactLinks.forEach(link => {
            expect(link).not.toBeNull();
            expect(link.getAttribute("href")).toEqual("/contact");
        });
    });

    it("should toggle the mobile navbar", () => {
        expect(component.showMobileNavLinks).toEqual("")

        component.toggleNavLinks()
        expect(component.showMobileNavLinks).toEqual("show")

        component.toggleNavLinks()
        expect(component.showMobileNavLinks).toEqual("")
    })
});
