import type { Config } from 'tailwindcss';

const config: Config = {
  content: ['./src/**/*.{html,ts}'],
  theme: {
    container: {
      center: true,
      padding: {
        DEFAULT: '1rem',
        sm: '1.25rem',
        lg: '1.5rem',
        xl: '2rem'
      }
    },
    extend: {
      colors: {
        primary: '#0B132B',
        secondary: '#F8FAFC',
        accent: '#70E000',
        surface: {
          DEFAULT: '#F8FAFC',
          low: '#EEF2F8',
          high: '#E1E8F2',
          card: '#FFFFFF'
        },
        ink: {
          DEFAULT: '#101828',
          muted: '#475467'
        },
        danger: '#B42318'
      },
      spacing: {
        18: '4.5rem',
        22: '5.5rem',
        30: '7.5rem'
      },
      fontFamily: {
        display: ['Inter', 'Roboto', 'ui-sans-serif', 'system-ui', 'sans-serif'],
        body: ['Inter', 'Roboto', 'ui-sans-serif', 'system-ui', 'sans-serif']
      },
      boxShadow: {
        ambient: '0 20px 40px rgba(11, 19, 43, 0.12)',
        float: '0 12px 28px rgba(11, 19, 43, 0.18)'
      },
      keyframes: {
        actionPulse: {
          '0%, 100%': { transform: 'scale(1)', boxShadow: '0 0 0 0 rgba(112, 224, 0, 0.28)' },
          '50%': { transform: 'scale(1.02)', boxShadow: '0 0 0 10px rgba(112, 224, 0, 0)' }
        },
        shimmer: {
          '0%': { backgroundPosition: '200% 0' },
          '100%': { backgroundPosition: '-200% 0' }
        }
      },
      animation: {
        'action-pulse': 'actionPulse 1.6s ease-in-out infinite',
        shimmer: 'shimmer 1.8s linear infinite'
      }
    }
  },
  plugins: []
};

export default config;
