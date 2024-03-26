import { ComponentFixture, TestBed } from '@angular/core/testing';

import { LandingPageComponent } from './landing-page.component';

describe('LandingPageComponent', () => {
    let component: LandingPageComponent;
    let fixture: ComponentFixture<LandingPageComponent>;

    beforeEach(async () => {
        await TestBed.configureTestingModule({
            declarations: [LandingPageComponent]
        })
        .compileComponents();
    
        fixture = TestBed.createComponent(LandingPageComponent);
        component = fixture.componentInstance;
        fixture.detectChanges();
    });

    it('should create', () => {
        expect(component).toBeTruthy();
    });

    it('should have correct href for sign up link', () => {
        const linkElements: HTMLElement[] = fixture.nativeElement.querySelectorAll('a');
        const logoLink = Array.from(linkElements).find(element => element.textContent?.includes('Sign Up For Free'));
        expect(logoLink).not.toBeNull()
        expect(logoLink?.getAttribute("href")).toEqual("/signup")
    });
});
