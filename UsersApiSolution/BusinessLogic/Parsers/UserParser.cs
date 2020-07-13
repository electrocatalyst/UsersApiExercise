﻿using DbComm.Models;

namespace BusinessLogic.Parsers
{
    public class UserParser : IParser
    {
        UserDto IParser.ConvertToStandardizedUserDto(IPersonDto person)
        {
            CocaColaUserDto ccperson = (CocaColaUserDto) person;

            UserDto user = new UserDto();
            user.Id = ccperson.Id;
            user.Email = ccperson.Email;

            user.Nickname = ccperson.Email;
            user.FirstName = ccperson.Email;
            user.LastName = ccperson.Email;
            user.Age = 0;

            return user;
        }
    }
}