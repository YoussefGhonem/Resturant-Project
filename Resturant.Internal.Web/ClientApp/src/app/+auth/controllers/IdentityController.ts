export const IdentityController = {
  Login: `account/login`,
  ForgetPassword: (email: string) => `account/${email}/forget-password`,
  ResetPassword: (email: string) => `account/${email}/reset-password`,
}
